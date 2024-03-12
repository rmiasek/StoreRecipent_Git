using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecipentStore.Dto
{
    public class BillCreateDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole nazwa jest wymagane")]
        public string Name { get; set; }

        [Display(Name = "Wystawiono")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Wartość")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Wartość nie może być mniejsza od zera.")]
        public double Price { get; set; }

        [Display(Name = "Plik")]
        public IFormFile FileUpload { get; set; }

        [Display(Name = "Typ dokumentu")]
        public int BillTypeID { get; set; }

        [Display(Name = "Sklep")]
        public int ShopID { get; set; }
    }

}
