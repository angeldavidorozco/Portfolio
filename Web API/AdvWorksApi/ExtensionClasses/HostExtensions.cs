﻿using Serilog;
using Serilog.Events;
namespace AdvWorksAPI.ExtensionClasses;
public static class HostExtension 
{
    public static IHostBuilder ConfigureSeriLog(this IHostBuilder host) 
    { 
        return host.UseSerilog((ctx, lc) => {       
            
            // Log to Console
            
            lc.WriteTo.Console();       
            
            
            // Log to Rolling File
            lc.WriteTo.File("Logs/InfoLog-.txt",        
                rollingInterval: RollingInterval.Day,       
                restrictedToMinimumLevel: LogEventLevel.Information);       
            
            
            // Log Errors to Rolling File
            lc.WriteTo.File("Logs/ErrorLog-.txt",         
                rollingInterval: RollingInterval.Day,         
                restrictedToMinimumLevel: LogEventLevel.Error);     
        });   
    } 
}