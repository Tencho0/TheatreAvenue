namespace TheatreAvenue.Models.Interfaces
{
    public interface IUserAdminViewModel
    {
        string UniqueToken { get; set; }

        bool IsAdmin { get; set; }
    }
}
