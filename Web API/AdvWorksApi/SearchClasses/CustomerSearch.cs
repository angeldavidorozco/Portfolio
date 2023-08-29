using AdvWorksAPI.BaseClasses;
namespace AdvWorksAPI.SearchClasses; 
public class CustomerSearch : SearchBase 
{
    public CustomerSearch() 
    {
        OrderBy = "LastName";
        FirstName = string.Empty;
        LastName = string.Empty; 
        Title = string.Empty; 
    } 
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public string? Title { get; set; } 
}
