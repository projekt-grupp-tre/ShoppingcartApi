using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
	public class PromoCodeEntity
	{
		[Key]
		public int Id { get; set; }
		public string PromoCode { get; set; } = null!;

		//one to many shoppingcarts?
		public virtual ICollection<ShoppingCartEntity>? ShoppingCarts { get; set; } = new HashSet<ShoppingCartEntity>();
	}
}