using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.Models.DbModels
{
    public class Skladnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSkladnika { get; set; }

        [Required]
        public string NazwaSkladnika { get; set; }

        public Skladnik(string nazwaSkladnika)
        {
            NazwaSkladnika = nazwaSkladnika;
        }
    }
}
