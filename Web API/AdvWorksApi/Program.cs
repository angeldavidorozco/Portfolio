using System.Globalization;
using AdvWorksAPI.EntityLayer2;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer2;
using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.ExtensionClasses;
using AdvWorksAPI.SearchClasses;

// ********************************************** 
// Create a WebApplicationBuilder object 
// to configure the how the ASP.NET service runs 

// 2nd line changes the culture information of the project
// that way it wont crash with the date formats
// ********************************************** 


var builder = WebApplication.CreateBuilder(args);
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

// ********************************************** 
// Add and Configure Services 
// ********************************************** 
// Add & Configure Global Application Settings
builder.ConfigureGlobalSettings();

// Add & Configure AdventureWorksLT DbContext
builder.Services.ConfigureAdventureWorksDB(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add & Configure Repository Classes
builder.Services.AddRepositoryClasses(); 


// Read "AdvWorksAPI" section
// Use the IOptionsMonitor<AdvWorksAPIDefaults> in controller's constructor
builder.Services.Configure<AdvWorksAPIDefaults>(builder.Configuration.GetSection("AdvWorksAPI"));

//Scoped service
//builder.Services.AddScoped<AdvWorksAPIDefaults, AdvWorksAPIDefaults>();
//Add and Configure Repository Classes
builder.Services.AddScoped<IRepository<Customer, CustomerSearch>, CustomerRepository>();


//// Configure logging to Console & File using Serilog
//builder.Host.UseSerilog((ctx, lc) => 
//{   
//// Log to Console
//lc.WriteTo.Console();
//// Log to Rolling File
//lc.WriteTo.File("Logs/InfoLog-.txt", 
//rollingInterval: RollingInterval.Day, 
//restrictedToMinimumLevel: LogEventLevel.Information);
//// Log Errors to Rolling File
//lc.WriteTo.File("Logs/ErrorLog-.txt",     
// rollingInterval: RollingInterval.Day,     
//restrictedToMinimumLevel: LogEventLevel.Error); 

//});

// Add & Configure Logging using Serilog
builder.Host.ConfigureSeriLog();



//// Add CORS
//builder.Services.AddCors(options => {   
//options.AddPolicy(AdvWorksAPIConstants.CORS_POLICY,     
//builder =>     
//{       
//builder.AllowAnyOrigin();
////builder.WithOrigins("http://localhost:nnnn", "http://www.example.com");
////builder.WithOrigins("http://localhost:nnnn", "http://www.example.com").AllowAnyMethod();
////builder.WithOrigins("http://localhost:nnnn", "http://www.example.com").WithMethods("GET", "POST", "PUT");
//}); 
//}); 

//// Add and Configure
//builder.Services.AddAuthentication();
//

// Add & Configure JWT Authentication
builder.Services.ConfigureJwtAuthentication(

builder.Configuration.GetRequiredSection("AdvWorksAPI").Get<AdvWorksAPIDefaults>());


// Add & Configure JWT Authorization
builder.Services.ConfigureJwtAuthorization();

// Add & Configure CORS
builder.Services.ConfigureCors();

//singleton
//builder.Services.AddSingleton<AdvWorksAPIDefaults, AdvWorksAPIDefaults>();



// Configure ASP.NET to use the Controller model 
var mvcBuilder = builder.Services.AddControllers();
//// Configure JSON Options
//mvcBuilder.AddJsonOptions(options => {   
//// Make all property names start with upper-case
//options.JsonSerializerOptions.PropertyNamingPolicy = null;

//// Ignore "readonly" fields 
//options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
//});

// Add & Configure JSON Options
mvcBuilder.ConfigureJsonOptions(); 


// Configure XML Formatters
mvcBuilder.AddXmlSerializerFormatters();


//// Configure Open API (Swagger) 
//// More Info: https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Add & Configure Open API (Swagger)
builder.Services.ConfigureOpenAPI(); 

// ********************************************** 
// After adding and configuring services 
// Create an instance of a WebApplication object 
// ********************************************** 
var app = builder.Build();

// ********************************************** 
// Configure the HTTP Request Pipeline 
// ********************************************** 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Exception Handling Middleware
if (app.Environment.IsDevelopment()) 
{   
    app.UseExceptionHandler("/DevelopmentError"); 
} 
else 
{   
    app.UseExceptionHandler("/ProductionError"); 
}

// Handle status code errors in the range 400-599
app.UseStatusCodePagesWithReExecute("/StatusCodeHandler/ {0}");

// Enable CORS Middleware
app.UseCors(AdvWorksAPIConstants.CORS_POLICY);

// Enable Authentication & Authorization Middleware
app.UseAuthentication(); 
app.UseAuthorization();

// Enable the Endpoints of Controller Action Methods
app.MapControllers();

// Run the Application 
app.Run();
