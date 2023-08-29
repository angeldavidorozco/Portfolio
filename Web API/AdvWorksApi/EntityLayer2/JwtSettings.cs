namespace AdvWorksAPI.EntityLayer2; 
public class JwtSettings 
{ 
    public JwtSettings() 
    { 
        Key = "A_KEY"; 
        Issuer = "http://localhost:nnnn"; 
        Audience = "Audience"; 
        MinutesToExpiration = 30; 
    } 
    public string Key { get; set; } 
    public string Issuer { get; set; } 
    public string Audience { get; set; }
    public int MinutesToExpiration { get; set; } 
}