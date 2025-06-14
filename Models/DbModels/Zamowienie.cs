using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.Models.DbModels
{
    public enum Status {przygotowywany, gotowy, wydany, anulowany }
    public class Zamowienie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdZamowienia { get; set; }
        [Required]
        public DateTime DataZamowienia { get; set; }
        [Required]
        public decimal KwotaZamowienia { get; set; }

        public Status StatusZamowienia { get; set; }

        public Zamowienie()
        {
            DataZamowienia = DateTime.Now;
            KwotaZamowienia = 0;
            StatusZamowienia = Status.przygotowywany;
        }

    }
}
