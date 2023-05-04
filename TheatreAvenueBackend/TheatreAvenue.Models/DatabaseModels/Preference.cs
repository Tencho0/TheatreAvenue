
using System.ComponentModel.DataAnnotations.Schema;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.DatabaseModels
{
    // This code defines the "Preference" class which implements both the "IPreference" and "IEntityBase" interfaces.
    public class Preference: IPreference, IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //"Id" property which is decorated with the "DatabaseGenerated" attribute and set to auto-generate the value.

        public string Genre { get; set; } //"Genre" property to store the genre preference of the user.
    }
}
