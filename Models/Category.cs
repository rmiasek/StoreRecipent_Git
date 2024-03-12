using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public ICollection<Shoping> Shoping { get; set; }
    }
}