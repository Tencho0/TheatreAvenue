namespace TheatreAvenue.Models.Interfaces
{
    public interface IRegisterViewModel
    {
        string Name { get; set; }
        
        string SureName { get; set; }
        
        string Email { get; set; }
        
        string Password { get; set; }

        bool IsAdmin { get; set; }
    }
}
