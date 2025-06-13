using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.Models.DbModels
{
    public class Kategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKategorii { get; set; }

        [Required]
        public string Name { get; set; }

        public Kategoria(string name)
        {
            Name = name;
        }
      
    }
}
