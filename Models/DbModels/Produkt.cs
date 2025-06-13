using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.Models.DbModels
{
    public class Produkt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduktu { get; set; }
        [Required]
        public string NazwaProduktu { get; set; }
        [ForeignKey("IdKategorii")]
        public virtual Kategoria? Kategoria { get; set; }

        public Produkt()
        {

        }
        public Produkt(string nazwa, Kategoria? kategoria)
        {
            NazwaProduktu = nazwa;
            Kategoria = kategoria;
        }
    }
}
