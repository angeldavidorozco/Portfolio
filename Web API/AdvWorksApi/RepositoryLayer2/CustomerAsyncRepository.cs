using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.EntityLayer2;
using AdvWorksAPI.Models;
using AdvWorksAPI.SearchClasses;
using Microsoft.EntityFrameworkCore;

namespace AdvWorksAPI.RepositoryLayer2;
/// <summary>
/// Asynchronous access to Customer data asynchronously ///
/// </summary> 
public partial class CustomerRepository 
{
    
    #region GetAsync Method   
    /// <summary>   
    /// /// Get all Customer objects asynchronously   
    /// /// </summary>  
    /// /// <returns>A list of Customer objects
    /// </returns>   
    public async Task<List<Customer>> GetAsync()   
    {    
        return await _DbContext.Customers.OrderBy(row => row.LastName).ToListAsync(); 
    }
    #endregion

    #region GetAsync(id) Method 
    public async Task<Customer?> GetAsync(int id) 
    {  
        return await _DbContext.Customers.Where(row => row.CustomerID == id).FirstOrDefaultAsync();
    }
    #endregion

    #region SearchAsync Methods 
    public async Task<List<Customer>> SearchAsync(CustomerSearch search) 
    { 
        IQueryable<Customer> query = _DbContext.Customers;   
        // Add WHERE clause(s)
        query = AddWhereClause(query, search);    
        // Add ORDER BY clause(s)
        query = AddOrderByClause(query, search); 
        return await query.ToListAsync(); 

    }
    #endregion 

}