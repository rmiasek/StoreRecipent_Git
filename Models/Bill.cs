using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Models
{
    public class Bill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [Column(TypeName = "decimal(19, 4)")]
        public double Price { get; set; }

        public string File {  get; set; }

        [Column(TypeName = "varchar(4)")]
        public string FileExtension { get; set; }

        [ForeignKey("BillType")]
        public int BillTypeID { get; set; }

        public BillType BillType { get; set; }

        [ForeignKey("Shop")]
        public int ShopID { get; set; }

        public Shop Shop { get; set; }

        public ICollection<Shoping> Shoping { get; set; }

    }
}