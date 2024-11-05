using Infrastructure.Interfaces;
using System.Data.SqlTypes;

namespace ShoppingcartApi.Dtos
{
	public class ProductDto : IProductDto
	{
		public string ProductId { get; set; } = null!;
		public string UserId { get; set; } = null!;		 
		public int Quantity { get; set; }
	}
}
