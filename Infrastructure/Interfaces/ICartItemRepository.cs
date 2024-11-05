using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces;

public interface ICartItemRepository
{
	//går ej referera infra -> ShoppingcartApi proj pga circular dependency
	// därav skapar man en IProductDto
	//i riktiga DTOn referar man till IproductDto

	Task<CartItemEntity> CreateCartItemAsync(CartItemEntity entity, ShoppingCartEntity shoppingCartEntity); 

}
