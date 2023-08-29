using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.EntityLayer2;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using AdvWorksAPI.Models;
using Microsoft.EntityFrameworkCore;
using AdvWorksAPI.SearchClasses;

namespace AdvWorksAPI.ExtensionClasses; 
public static class ServiceExtension 
{ 
    public static IServiceCollection ConfigureCors(this IServiceCollection services) 
    
    {     // Add & Configure CORS
          return services.AddCors(options =>     
          {       
              options.AddPolicy(AdvWorksAPIConstants.CORS_POLICY,        
                  builder =>         
                  {           
                      builder.WithOrigins("http://localhost:5113");         
                  });    
          });  
    }

    public static void AddRepositoryClasses(this IServiceCollection services)
    {   
        // Add Repository Classes
        services.AddScoped<IRepository<Customer, CustomerSearch>, CustomerRepository>(); 
    }

    public static AuthenticationBuilder ConfigureJwtAuthentication(this IServiceCollection services, AdvWorksAPIDefaults settings)
    {   

        // Add Authentication to Services
        return services.AddAuthentication(options =>   
        {     
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;     
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;     
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;   
        }).AddJwtBearer(jwtOptions =>   
        {     
            jwtOptions.TokenValidationParameters =       
            new TokenValidationParameters       
            {         
                ValidIssuer = settings.JWTSettings.Issuer,         
                ValidAudience = settings.JWTSettings.Audience,         
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWTSettings.Key)),         
                ValidateIssuer = true,         
                ValidateAudience = true,        
                ValidateLifetime = true,        
                ValidateIssuerSigningKey = true,       
                ClockSkew = TimeSpan.FromMinutes(settings.JWTSettings.MinutesToExpiration)       
            };   
        }); 
    }

    public static IServiceCollection ConfigureJwtAuthorization(this IServiceCollection services) 
    {
        return services.AddAuthorization(options => 
        { 
            options.AddPolicy("GetCustomersClaim", policy => policy.RequireClaim("GetCustomers"));
            options.AddPolicy("GetACustomerClaim", policy => policy.RequireClaim("GetACustomer")); 
            options.AddPolicy("SearchClaim", policy => policy.RequireClaim("Search"));
            options.AddPolicy("AddCustomerClaim", policy => policy.RequireClaim("AddCustomer"));
            options.AddPolicy("UpdateCustomerClaim", policy => policy.RequireClaim("UpdateCustomer"));
        });
    }


    public static IServiceCollection ConfigureOpenAPI(this IServiceCollection services)
    {  
        // Configure Open API (Swagger)  
        // More Info: https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();   
        return services.AddSwaggerGen(options =>   
        {     
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme     
            {       
                Scheme = "Bearer",      
                BearerFormat = "JWT",   
                In = ParameterLocation.Header,   
                Name = "Authorization",    
                Description = "Bearer Authentication with JWT Token",   
                Type = SecuritySchemeType.Http    
            }); 
            
            options.AddSecurityRequirement(new OpenApiSecurityRequirement    
            {    
                {   
                    new OpenApiSecurityScheme       
                    {         
                        Reference = new OpenApiReference        
                        {          
                            Id = "Bearer",      
                            Type = ReferenceType.SecurityScheme   
                        }       
                    },  
                    
                    new List<string>()   
                    
                }    
            });  
        });
    }

    public static IServiceCollection ConfigureAdventureWorksDB(this IServiceCollection services, string? cnn)
    {  
        // Setup the DbContext object
        return services.AddDbContext<AdvWorksLTDbContext>(     
            options => options.UseSqlServer(cnn)); 
    } 

    
}