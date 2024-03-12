using System.ComponentModel.DataAnnotations;

namespace RecipentStore.Dto
{
    public class ShopDto
    {
        [Key]
        public int ShopId { get; set; }

        [Display(Name = "Nazwa")]
        public string ShopName { get; set; }

        [Display(Name = "Nip")]
        public string NIP { get; set; } = null!;

    }
}
