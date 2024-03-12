using RecipentStore.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Dto
{
    public class ShopingCreateDto
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string ShopingName { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        [Display(Name = "Rachunek")]
        public int BillID { get; set; }

        [Display(Name = "Kategoria")]
        public int CategoryID { get; set; }

    }
}
