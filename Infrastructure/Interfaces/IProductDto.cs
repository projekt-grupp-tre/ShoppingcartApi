namespace Infrastructure.Interfaces
{
	public interface IProductDto
	{
		public string ProductId { get; set; }
		public string UserId { get; set; }
		public int Quantity { get; set; }
	}

}