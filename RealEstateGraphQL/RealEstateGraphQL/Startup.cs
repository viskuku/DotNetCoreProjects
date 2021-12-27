using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstateGraphQL.DataAccess.Repositories;
using RealEstateGraphQL.DataAccess.Repositories.Contracts;
using RealEstateGraphQL.Database;
using RealEstateGraphQL.Queries;
using RealEstateGraphQL.Schema;
using RealEstateGraphQL.Types;

namespace RealEstateGraphQL
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
            services.AddMvc();
            services.AddRazorPages();
            services.AddTransient<IPropertyRepository, PropertyRepository>();

            services.AddDbContext<RealEstateContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]), ServiceLifetime.Singleton);
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RealEstateContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            // app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            app.UseGraphiQl();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                
            });

            db.EnsureSeedData();
        }
    }
}
