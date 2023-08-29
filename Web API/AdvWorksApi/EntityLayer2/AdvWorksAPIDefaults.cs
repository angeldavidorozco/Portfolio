using AdvWorksAPI.EntityLayer2;

namespace AdvWorksAPI.EntityLayer2; 
public class AdvWorksAPIDefaults 
{ 


    public AdvWorksAPIDefaults() 
    { 
        Created = DateTime.Now;
        DefaultTitle = "Ms."; 
        DefaultEmail = "LastName.FirstName@advworks.com";
        InfoMessageDefault = string.Empty; 
        JWTSettings = new();

    } 


    public DateTime Created { get; set; } 
    public string DefaultTitle { get; set; } 
    public string DefaultEmail { get; set; }
    public string InfoMessageDefault { get; set; }
    public JwtSettings JWTSettings { get; set; }

}