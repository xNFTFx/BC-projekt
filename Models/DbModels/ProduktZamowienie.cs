using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.Models.DbModels
{
    public class ProduktZamowienie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PzId { get; set; }

        public int ProduktId { get; set; }
        [ForeignKey("ProduktId")]
        public virtual Produkt Produkt { get; set; }

        public int ZamowienieId { get; set; }
        [ForeignKey("ZamowienieId")]
        public virtual Zamowienie Zamowienie { get; set; }

        [Required]
        public int Ilosc { get; set; }
    }

}
