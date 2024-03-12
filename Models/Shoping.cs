using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Models
{
    public class Shoping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(19, 4)")]
        public double Price { get; set; }

        [ForeignKey("Bill")]
        public int BillID { get; set; }

        public Bill Bill { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }


        public Category category { get; set; }


    }
}