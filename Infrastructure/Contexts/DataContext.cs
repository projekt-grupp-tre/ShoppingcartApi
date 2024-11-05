using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
	public class DataContext :DbContext
	{
	
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ 

		}




		public virtual DbSet<CartItemEntity> CartItems { get; set; }
		public virtual DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
		public virtual DbSet<PromoCodeEntity> PromoCodes { get; set; }
		


	}
}
