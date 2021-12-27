using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQLLearn.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.SystemTextJson;
using GraphQLLearn.GraphQL.Schemas;
using Autofac;
using Microsoft.AspNetCore.Http;
using GraphQLLearn.Repositores;
using GraphQLLearn.GraphQL.Schemas.Queries;
using GraphQL;
using GraphQL.Types;
using GraphQLLearn.GraphQL.Schemas.Mutations;

namespace GraphQLLearn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<MovieContext>(context => { context.UseInMemoryDatabase("MovieDb"); });

            services.AddGraphQL((options, provider) =>
            {
                //Load GraphQL Server Configuration
                var graphQLOptions = Configuration.GetSection("GraphQL").Get<GraphQLOptions>();

                options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                options.EnableMetrics = graphQLOptions.EnableMetrics;

                //Log Errors
                var logger = provider.GetRequiredService<ILogger<Startup>>();
                options.UnhandledExceptionDelegate = (ctx => logger.LogError($"{ctx.OriginalException.Message} Occured"));
            })
              .AddGraphTypes()
              .AddDataLoader()
              .AddSystemTextJson();
        }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>().SingleInstance();
            //  builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<QueryObject>().AsSelf().SingleInstance();
            builder.RegisterType<MutationObject>().AsSelf().SingleInstance();

            //builder.RegisterType<MovieReviewSchema>().AsSelf().SingleInstance();
            builder.RegisterType<MovieReviewSchema>().As<ISchema>().SingleInstance();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseGraphQLAltair(new GraphQLAltairOptions { Path = "/" });
            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<ISchema>();
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
            });
        }
    }
}
