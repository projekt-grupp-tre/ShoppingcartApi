namespace Infrastructure.Interfaces
{
	public interface IProductDto
	{
		public string ProductId { get; set; }
		public string UserEmail { get; set; }
		public int Quantity { get; set; }
	}

}