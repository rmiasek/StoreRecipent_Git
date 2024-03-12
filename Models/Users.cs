using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipentStore.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; } = null!;

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Surname { get; set; } 
        
        public string PasswordHash { get; set; } = null!;

        public ICollection<Shop> Shops { get; set; }
    }
}