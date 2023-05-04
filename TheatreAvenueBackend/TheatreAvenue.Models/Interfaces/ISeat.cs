using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface ISeat
    {
        public int Number { get; set; }

        int Row { get; set; }

        bool Booked { get; set; }

        User User { get; set; }
    }
}
