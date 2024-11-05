using Infrastructure.Interfaces;

namespace Infrastructure.Dtos
{
	public class ProductDto : IProductDto
	{
		public string ProductId { get; set; } = null!;
		public string UserEmail { get; set; } = null!;		 
		public int Quantity { get; set; }
	}
}
