using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Factories
{
	public static class IProductToCartItemFactory
	{	
		public static CartItemEntity ConvertFromProductToEntity(IProductDto product)
		{
			var entity = new CartItemEntity
			{
				ProductId = product.ProductId,
				Quantity = product.Quantity,	
				Created = DateTime.UtcNow,
			};

			// entity.ShoppingCartId = ? ;

			return entity;

		}	
	}
}
