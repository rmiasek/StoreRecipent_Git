using Microsoft.EntityFrameworkCore;
using RecipentStore.Models;
using RecipentStore.Dto;

namespace RecipentStore.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Shoping> Shopings { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<RecipentStore.Dto.ShopCreateDto> ShopCreateDto { get; set; } = default!;
        public DbSet<RecipentStore.Dto.ShopingDto> ShopingDto { get; set; } = default!;
        public DbSet<RecipentStore.Dto.ShopingCreateDto> ShopingCreateDto { get; set; } = default!;
     }
    
 
}

