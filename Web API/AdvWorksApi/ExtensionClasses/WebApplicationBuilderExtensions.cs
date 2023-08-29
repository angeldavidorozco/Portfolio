using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.EntityLayer2;
namespace AdvWorksAPI.ExtensionClasses
{
    public static class WebApplicationBuilderExtensions
    {    
        // Configure Global Settings
        public static void ConfigureGlobalSettings(this WebApplicationBuilder builder)     
        {  
            
            // The following line is only used for the SettingsController
            builder.Services.AddSingleton<AdvWorksAPIDefaults, AdvWorksAPIDefaults>();  

            
            // Read "AdvWorksAPI" section       
            // Use the IOptionsMonitor<AdvWorksAPIDefaults> in controller's constructor
            builder.Services.Configure<AdvWorksAPIDefaults>(builder. Configuration.GetSection("AdvWorksAPI")); 
            
        }   
    } 
} 
