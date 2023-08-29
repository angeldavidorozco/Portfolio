using AdvWorksAPI.BaseClasses;
using AdvWorksAPI.EntityLayer2;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.SearchClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace AdvWorksAPI.Controllers;  
/// <summary> 
/// Asynchronous Action Methods 
/// </summary> 
[Route("api/[controller]")] 
[ApiController] 
public partial class CustomerAsyncController : ControllerBaseAPI 
{  
    private readonly IRepository<Customer, CustomerSearch> _Repo; 
    private readonly AdvWorksAPIDefaults _Settings;    
    public CustomerAsyncController(IRepository<Customer, CustomerSearch> repo, ILogger<CustomerController> logger, IOptionsMonitor<AdvWorksAPIDefaults> settings) : base(logger)  
    {    
        _Repo = repo;    
        _Settings = settings.CurrentValue;  
    }   
    #region GetAsync Method   
    [HttpGet]  
    [ProducesResponseType(StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]  
    public async Task<ActionResult<IEnumerable<Customer>>> GetAsync() 
    {   
        ActionResult<IEnumerable<Customer>> ret; 
        List<Customer> list;    
        InfoMessage = "No Customers are available.";  
        try
        {     
            // Get all data
            var task = await _Repo.GetAsync(); 
            // Convert data to a List<T>
            list = task.ToList();   
            if (list != null && list.Count > 0)
            {       
                return StatusCode(StatusCodes.Status200OK, list);   
            }   
            else 
            {   
                return StatusCode(StatusCodes.Status404NotFound, InfoMessage);   
            }   
        }   
        catch (Exception ex)
        {   
            InfoMessage = _Settings.InfoMessageDefault.Replace("{Verb}", "GETAsync").Replace("{ClassName}", "Customer"); 
            ErrorLogMessage = "Error in CustomerController.GetAsync()";   
            ret = HandleException<IEnumerable<Customer>>(ex);   
        }    
        return ret; 
    }
    #endregion

    #region GetAsync(id) Method 
    [HttpGet("{id}")] 
    [ProducesResponseType(StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Customer>> GetAsync(int id) 
    {   
        ActionResult<Customer> ret;   
        Customer? entity;   
        entity = await _Repo.GetAsync(id);
        if (entity != null)
        {    
            // Found data, return '200 OK'
            ret = StatusCode(StatusCodes.Status200OK, entity); 
        }  
        else 
        {   
            // Did not find data, return '404 Not Found'
            ret = StatusCode(StatusCodes.Status404NotFound, $"Can't find Customer with a Customer Id of '{id}'."); 
        }   
        return ret;
    }
    #endregion 

    #region SearchAsync Method
    [HttpGet] 
    [Route("Search")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
    public async Task<ActionResult<IEnumerable<Customer>>> SearchAsync([FromQuery()] CustomerSearch search)
    {  
        ActionResult<IEnumerable<Customer>> ret;  
        List<Customer> list;   
        InfoMessage = "Can't find products matching the criteria passed in.";   
        try 
        {    
            // Search for Data
            var task = await _Repo.SearchAsync(search);   
            list = task.ToList();   
            if (list != null && list.Count > 0) 
            {    
                return StatusCode(StatusCodes.Status200OK, list);   
            }  
            else 
            {   
                return StatusCode(StatusCodes.Status404NotFound, InfoMessage);    
            }  
        }   
        catch (Exception ex) 
        {    
            InfoMessage = _Settings.InfoMessageDefault.Replace("{Verb}", "SEARCHAsync").Replace("{ClassName}", "Customer"); 
            ErrorLogMessage = "Error in CustomerController.SearchAsync()";
            ret = HandleException<IEnumerable<Customer>>(ex); 
        }   
        return ret; 
    } 
    #endregion 
}