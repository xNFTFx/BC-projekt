using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bc.Models.DbModels { 
public class Kategoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdKategorii { get; set; }

    [Required]
    public string Name { get; set; }

    public Kategoria() { }

    public Kategoria(string name)
    {
        Name = name;
    }
}
}

