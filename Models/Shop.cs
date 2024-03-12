using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Models
{
    public class Shop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string NIP { get; set; } = null!;

        [ForeignKey("User")]
        public int UserID { get; set; } 

        public Users User { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}
