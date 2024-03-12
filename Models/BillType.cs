using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Models
{
    public class BillType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Name { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}
