using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
	public class CartItemEntity 
	{
		[Key]
		public int Id { get; set; }
		public string ProductId { get; set; } = null!;
		public int Quantity { get; set; } // antalet av en specifik produkt?
		public DateTime Created {  get; set; } = DateTime.UtcNow;


		
		[ForeignKey(nameof(ShoppingCartEntity))]
		public int ShoppingCartId { get; set; }
		public virtual ShoppingCartEntity ShoppingCartEntity { get; set; } = null!;
	}
}
