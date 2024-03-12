
using System.ComponentModel.DataAnnotations;

namespace RecipentStore.Dto
{
    public class BillDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Wystawiono")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Wartość")]
        public double Price { get; set; }

        public string File { get; set; }

        public string FileExtension { get; set; }

        public int BillTypeID { get; set; }

        public string BillTypeName { get; set; }

        public int ShopID { get; set; }

        [Display(Name = "Sklep")]
        public string ShopName { get; set; }

        [Display(Name = "Nip sklepu")]
        public string ShopNip { get; set; }

    }
}
