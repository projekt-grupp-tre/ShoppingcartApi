using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			return new CartItemEntity();

		}
		
	}
}
