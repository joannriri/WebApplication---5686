using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerQueen_PACUR12400.Data
{
	public class AppDbContext : IdentityDbContext<tbl_appuser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
		}
        public DbSet<tbl_products> Products { get; set; }
        public DbSet<tbl_Contact> ContactForm { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<UserCheckout> UserCheckout { get; set; }
        public DbSet<CheckoutItem> CheckoutItem { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var user = new IdentityRole("user");
            admin.NormalizedName = "user";

            builder.Entity<IdentityRole>().HasData(admin,user);
        }

    }
}
