﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace AdvWorksAPI.Controllers; 

public class ErrorController : ControllerBase 
{ 
    [Route("/ProductionError")]
    [ApiExplorerSettings(IgnoreApi = true)] 
    public IActionResult ProductionErrorHandler()    
    { 
        string msg = "Unknown Error"; 
        var features = HttpContext.Features.Get<IExceptionHandlerFeature>()!; 
        if (features != null) 
        { 
            msg = features.Error.Message; 
        } 
        return StatusCode(StatusCodes.Status500InternalServerError, msg); 
    }


    [Route("/DevelopmentError")]
    [ApiExplorerSettings(IgnoreApi = true)] 
    public IActionResult DevelopmentErrorHandler() 
    { 
        string msg = "Unknown Error"; 
        var features = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        if (features != null) 
        { 
            msg = "Message: " + features.Error.Message; 
            msg += Environment.NewLine + "Source: " + features.Error.Source; 
            msg += Environment.NewLine + features.Error.StackTrace; 
        } 
        return StatusCode(StatusCodes.Status500InternalServerError, msg); 
    }

    [Route("/StatusCodeHandler/{code:int}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult StatusCodeHandler(int code)
    {
        IActionResult ret; string msg = $"Code is not handled: '{code}' ";


        //Get some path information
        var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>(); 
        if (feature != null) 
        { 
            msg += feature.OriginalPathBase 
                + feature.OriginalPath 
                + feature.OriginalQueryString; 
        }
        switch (code) 
        {
            case 401: 

                msg = $"You are not authorized for this route: '{msg}'"; 
                ret = StatusCode(StatusCodes.Status401Unauthorized, msg); 
                break;

            case 403: 
                msg = $"You are forbidden from accessing this route: '{msg}'";
                ret = StatusCode(StatusCodes.Status403Forbidden, msg);
                break;

            case 404: msg = $"API Route Was Not Found: '{msg}'"; 

                ret = StatusCode(StatusCodes.Status404NotFound, msg); 
                break; 

            default: 
                ret = StatusCode(StatusCodes.Status500InternalServerError, msg); 
                break; 

        }

        return ret;
    }
}
    
    
