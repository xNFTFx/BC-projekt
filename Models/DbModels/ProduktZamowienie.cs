using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.Models.DbModels
{
    public class ProduktZamowienie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PzId;

        [ForeignKey("IdProduktu")]
        public int ProduktId;
        [Required]
        public int Ilosc;
        [ForeignKey("IdZamowienia")]
        public int ZamowienieId;
    }
}
