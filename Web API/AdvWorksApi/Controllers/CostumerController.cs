using AdvWorksAPI.EntityLayer2; 
using AdvWorksAPI.RepositoryLayer2;
using AdvWorksAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AdvWorksAPI.BaseClasses;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AdvWorksAPI.SearchClasses;

namespace AdvWorksAPI.Controllers;  
[Route("api/[controller]")] 
[ApiController] 
public class CustomerController : ControllerBaseAPI 
{
    private readonly IRepository<Customer, CustomerSearch> _Repo;
    private readonly AdvWorksAPIDefaults _Settings;

    public CustomerController(IRepository<Customer, CustomerSearch> repo, ILogger<CustomerController> logger, IOptionsMonitor<AdvWorksAPIDefaults> settings) : base(logger)
    {
        _Repo = repo;
        _Settings = settings.CurrentValue;
    }

    [HttpGet]
    //[Authorize(Policy = "GetCustomersClaim")]
    [ProducesResponseType(StatusCodes.Status200OK)]   
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Produces("application/xml")]
    public ActionResult<IEnumerable<Customer>> Get()   
    {    
        
        ActionResult<IEnumerable<Customer>> ret;     
        List<Customer> list;
        InfoMessage = "No customers available.";

        try
        {
            // Intentionally Cause an Exception
            //throw new ApplicationException("ERROR!");

            // Get all data      
            list = _Repo.Get();
            if (list != null && list.Count > 0)
            {
                ret = StatusCode(StatusCodes.Status200OK, list);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound, InfoMessage);
            }
        }
        catch (Exception ex)
        {
            InfoMessage = _Settings.InfoMessageDefault.Replace("{Verb}", "GET").Replace("{ClassName}", "Customer");

            ErrorLogMessage = "Error in CustomerController.Get()";

            ret = HandleException<IEnumerable<Customer>>(ex);
        }

        return ret;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Customer> Get(int id)
    {
        ActionResult<Customer> ret; 

        Customer? entity; 

        entity = _Repo.Get(id); 

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

    //[HttpGet]
    //[Route("SearchByTitle")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public ActionResult<IEnumerable<Customer>> SearchByTitle(string title)
    //{

    //    ActionResult<IEnumerable<Customer>> ret; List<Customer> list;


    //    // Get all data
    //    list = _Repo.Get()     
    //        .Where(row => row.Title == title)     
    //        .OrderBy(row => row.LastName).ToList();  

    //    if (list != null && list.Count > 0) 
    //    {     
    //        ret = StatusCode(StatusCodes.Status200OK, list);
    //    }   
    //    else 
    //    {     
    //        ret = StatusCode(StatusCodes.Status404NotFound,       
    //            $"No Customers found matching the title '{title}'.");   
    //    }    
    //    return ret; 
    //}

    //[HttpGet]
    //[Route("SearchByFirstLast/First/{first}/Last/{last}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public ActionResult<IEnumerable<Customer>> SearchByFirstLast(string first, string last)
    //{
    //    ActionResult<IEnumerable<Customer>> ret; List<Customer> list; 


    //    // Get all data
    //    list = _Repo.Get()     
    //        .Where(row => row.FirstName.Contains(first, StringComparison.InvariantCultureIgnoreCase) &&            
    //        row.LastName.Contains(last, StringComparison.InvariantCultureIgnoreCase))     
    //        .OrderBy(row => row.LastName).ToList();    

    //    if (list != null && list.Count > 0) 
    //    {     
    //        ret = StatusCode(StatusCodes.Status200OK, list);   
    //    }   
    //    else 
    //    {     
    //        ret = StatusCode(StatusCodes.Status404NotFound,       
    //            "No Customers found matching the criteria passed in.");   
    //    }    
    //    return ret; 
    //}


    //[Consumes("application/xml")]
    //[Produces("application/xml")]



    #region Search Method 
    [HttpGet()] 
    [Route("Search")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
    public ActionResult<IEnumerable<Customer>> Search([FromQuery()] CustomerSearch search) 
    { 
        ActionResult<IEnumerable<Customer>> ret;  
        List<Customer> list; 
        InfoMessage = "Can't find products matching the criteria passed in."; 
        try 
        {     
            // Search for Data
            list = _Repo.Search(search); 
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
            InfoMessage = _Settings.InfoMessageDefault      
                .Replace("{Verb}", "SEARCH").Replace("{ClassName}", "Customer");  
            ErrorLogMessage = "Error in CustomerController.Search()";  
            ret = HandleException<IEnumerable<Customer>>(ex); 
        }    
        return ret; 
    }
    #endregion 


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Customer> Post([FromBody] Customer entity)
    {
        ActionResult<Customer> ret;
        // Serialize entity
        SerializeEntity<Customer>(entity);
        try
        {
            if (entity != null)
            {
                // Attempt to update the database
                entity = _Repo.Insert(entity);
                // Return a '201 Created' with the new entity
                ret = StatusCode(StatusCodes.Status201Created, entity);
            }
            else
            {
                InfoMessage = "Customer object passed to POST method is empty.";
                // Return a '400 Bad Request'
                ret = StatusCode(StatusCodes.Status400BadRequest, InfoMessage);
                // Log an informational message
                _Logger.LogInformation("{InfoMessage}", InfoMessage);
            }
        }
        catch (Exception ex)
        {
            InfoMessage = _Settings.InfoMessageDefault.Replace("{Verb}", "POST").Replace("{ClassName}", "Customer");
            // Return a '500 Internal Server Error'
            ErrorLogMessage = $"CustomerController.Post() - Exception trying to insert a new customer: {EntityAsJson}";
            ret = HandleException<Customer>(ex);
        }
        return ret;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Customer> Put(int id, [FromBody] Customer entity)
    {
        ActionResult<Customer> ret;   
        // Serialize entity
        SerializeEntity<Customer>(entity);    
        try 
        {
            if (entity != null)
            {
                // Attempt to locate the data to update
                Customer? current = _Repo.Get(id);
                if (current != null)
                {
                    // Combine changes into current record
                    entity = _Repo.SetValues(current, entity);
                    // Attempt to update the database
                    current = _Repo.Update(current);
                    // Pass back a '200 Ok'
                    ret = StatusCode(StatusCodes.Status200OK, current);
                }
                else
                {
                    InfoMessage = $"Can't find Customer Id '{id}' to update.";
                    // Did not find data, return '404 Not Found'
                    ret = StatusCode(StatusCodes.Status404NotFound, InfoMessage);
                    // Log an informational message
                    _Logger.LogInformation("{InfoMessage}", InfoMessage);
                }
            }
            else
            {
                InfoMessage = "Customer object passed to PUT method is empty.";
                // Return a '400 Bad Request'
                ret = StatusCode(StatusCodes.Status400BadRequest, InfoMessage);
                // Log an informational message
                _Logger.LogInformation("{InfoMessage}", InfoMessage);     
            }  
        }   
        catch (Exception ex) 
        {    
            InfoMessage = _Settings.InfoMessageDefault.Replace("{Verb}", "PUT").Replace("{ClassName}", "Customer");     
            // Return a '500 Internal Server Error'
            ErrorLogMessage = $"CustomerController.Put() - Exception trying to update Customer: {EntityAsJson}";   
            ret = HandleException<Customer>(ex);  
        }   
        return ret; 
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Customer> Delete(int id)
    {
        ActionResult<Customer> ret; 

        try
        {    
            // Attempt to delete from the database
            if (_Repo.Delete(id)) 
            {       
                // Return '204 No Content'
                ret = StatusCode(StatusCodes.Status204NoContent);    
            }    
            else 
            {       
                InfoMessage = $"Can't find Customer Id '{id}' to delete.";     
                // Did not find data, return '404 Not Found'
                ret = StatusCode(StatusCodes.Status404NotFound, InfoMessage);  
                // Log an informational message
                _Logger.LogInformation("{InfoMessage}", InfoMessage);   
            }  
        }   
        catch (Exception ex) 
        {    
            // Return generic message for the user
            InfoMessage = _Settings.InfoMessageDefault   
                .Replace("{Verb}", "DELETE")    
                .Replace("{ClassName}", "Customer"); 
            ErrorLogMessage = $"CustomerController.Delete() - Exception trying to delete CustomerID: '{id}'."; 
            ret = HandleException<Customer>(ex);  
        }   
        return ret; 
    } 


        
} 