using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdvWorksAPI.EntityLayer2; 
[Table("Customer", Schema = "SalesLT")] 
public partial class Customer 
{ 
    public Customer() 
    { 
        Title = string.Empty; 
        FirstName = string.Empty;
        MiddleName = string.Empty; 
        LastName = string.Empty;
        CompanyName = string.Empty;
        EmailAddress = string.Empty;
        Phone = string.Empty;
        PasswordHash = string.Empty; 
        PasswordSalt = string.Empty; 
        SalesPerson = string.Empty; 
        Suffix = string.Empty; 
    }
    

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required()] 
    public int CustomerID { get; set; }
    [Required()] 
    public bool NameStyle { get; set; }


    [StringLength(8, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")] //Data Validations
    public string? Title { get; set; }


    [Required()]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
    public string FirstName { get; set; }

    [StringLength(50, MinimumLength = 0, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
    public string? MiddleName { get; set; }


    [Required()]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
    public string LastName { get; set; }
    public string? Suffix { get; set; }
    public string? CompanyName { get; set; } 
    public string? SalesPerson { get; set; }
    public string? EmailAddress { get; set; }
    public string? Phone { get; set; }
    [Required()] 
    public string PasswordHash { get; set; }
    [Required()] 
    public string PasswordSalt { get; set; }
    [Required()] 
    public Guid Rowguid { get; set; } 
    [Required()]
    public DateTime ModifiedDate { get; set; } 


    #region ToString Override  
    public override string ToString()  
    {    
        return $"{LastName}, {FirstName} ({CustomerID})";  
    }  
    #endregion 
} 