using Microsoft.AspNetCore.Mvc;
using AdvWorksAPI.EntityLayer2;
using System.Text.Json;
using AdvWorksAPI.BaseClasses;

namespace AdvWorksAPI.Controllers; 


[Route("api/[controller]")]
[ApiController] 
public class LogTestController : ControllerBaseAPI 
{ 

    
    public LogTestController(ILogger<LogTestController> logger) : base(logger)
    { 
        
    }

    private void WriteLogMessages()
    {   
        // The following are in the Log Level order
        _Logger.LogTrace("This is a Trace log entry");   
        _Logger.LogDebug("This is a Debug log entry.");   
        _Logger.LogInformation("This is an Information log entry.");
        _Logger.LogWarning("This is a Warning log entry.");  
        _Logger.LogError("This is an Error log entry.");  
        _Logger.LogError(new ApplicationException("This is an exception."), "Exception Object");   
        _Logger.LogCritical("This is a Critical log entry."); 
    }

    [HttpGet]
    [Route("WriteMessages")]
    public string WriteMessages()
    {   
        // Write Log Messages
        WriteLogMessages();    
        return "Check Console Window...... or Log File"; 
    }

    private void LogCustomer()
    {   
        // Log an Object
        Customer entity = new()   
        {     
            CustomerID = 999,     
            FirstName = "Bruce",     
            LastName = "Jones",
            Title = "Mr.",     
            CompanyName = "Beach Computer Consulting", 
            EmailAddress = "Jones.Bruce@beachcomputerconsulting.com", 
            Phone = "(714) 555-5555",     
            ModifiedDate = DateTime.Now   
        };

        string json = base.SerializeEntity<Customer>(entity);

        _Logger.LogInformation("Customer = {json}", json);
    
    }

    [HttpGet]
    [Route("LogObject")]
    public string LogObject()
    {   
        // Write Customer Object to Log
        LogCustomer();    
        return "Check Console Window or Log File"; 
    } 

    
}