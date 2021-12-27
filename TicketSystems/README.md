# Ticket Systems
## Summary
 ## In Memeory EF core
 
 Under Configure Services
 
          services.AddDbContext<BugContext>(options =>
                {
                    options.UseInMemoryDatabase("DatabaseName");
                });
 Under Configure
  
          context.Database.EnsureDeleted();
          context.Database.EnsureCreated();
          
 ## Register Filter Globally
 
 Register Filter as Middleware - Under Configure Services
 
         services.AddControllers(options => { options.Filters.Add<FilterName>(); });
         
## Resource Filter - IResourceFilter

1. Read the http request path - 
      
      context.HttpContext.Request.Path.Value

## Action Filter - ActionFilterAttribute

1. Read the Request body object/model as action argument
    
    context.ActionArguments["Object"] as Class
2. Set the ModelState to report the Model error using AddModelError in Context
    
    context.ModelState.AddModelError("ModelPropertyName", "Message for invoking client");
3. Finally set the context.Result - short circuit
   
   context.Result = new BadRequestObjectResult(context.ModelState);
   
## Get the Location URL - Which is the redirection URL after Making Post/Or any http call, GetByID - can be any action method
  
   CreatedAtAction(nameof(GetById), new { id = ModelObject.Property }, ModelName);
   
## Model validation using ValidationAttribute

1. Override IsValid method, return ValidationResult
2. Use the ObjetInstance to get the Model Object to check the property
    
    validationContext.ObjectInstance as ModelClass;
