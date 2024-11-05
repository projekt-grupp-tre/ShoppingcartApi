using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
	public class DataContext :DbContext
	{
	
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ 

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<ShoppingCartEntity>()
			//.HasMany(c => c.CartItems) // En CartModel har många CartItems
			//.WithOne(ci => ci.ShoppingCartEntity)    // En CartItem har en CartModel
			//.HasForeignKey(ci => ci.); // Anger främmande nyckel

		}


		public virtual DbSet<CartItemEntity> CartItems { get; set; }
		public virtual DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
		public virtual DbSet<PromoCodeEntity> PromoCodes { get; set; }
		


	}
}
