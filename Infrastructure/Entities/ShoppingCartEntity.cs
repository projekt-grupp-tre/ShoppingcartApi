using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
	public class ShoppingCartEntity
	{
		public int Id { get; set; }

		public string UserEmail { get; set; } = null!;  //kontrollera med user gänget kring typ?

		public int Quantity { get; set; } //kvantitet av totala antalet produkter/cartitems i kundvagnen


		[Column(TypeName = "Money")]
		public decimal Totalprice { get; set; }

		public DateTime Created { get; set; } = DateTime.UtcNow;

		//för enklare navigering
		public virtual ICollection<CartItemEntity>? CartItems { get; set; } = new List<CartItemEntity>();

		//en shoppingcart KAN ha en Promocode
		[ForeignKey("PromoCodeId")]
		public int? PromoCodeId { get; set; }
		public virtual PromoCodeEntity? PromoCode { get; set; }

	}
}