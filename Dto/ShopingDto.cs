using RecipentStore.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Dto
{
    public class ShopingDto
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string ShopingName { get; set; }

        [Display(Name = "Cena")]
        public double Price { get; set; }

        public int BillID { get; set; }

        [Display(Name = "Rachunek")]
        public string BillName { get; set; }

        public int CategoryID { get; set; }

        [Display(Name = "Kategoria")]
        public string CategoryName { get; set; }

        [Display(Name = "Nazwa")]
        public int ShopID { get; set; }

        [Display(Name = "Sklep")]
        public string ShopName { get; set; }


        
    }
}
