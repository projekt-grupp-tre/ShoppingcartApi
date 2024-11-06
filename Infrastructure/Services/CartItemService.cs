using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class CartItemService : ICartItemService
	{
		private readonly ICartItemRepository _cartItemRepository;
		private readonly IShoppingCartRepository _shoppingCartRepository;

		public CartItemService(ICartItemRepository cartItemRepository, IShoppingCartRepository shoppingCartRepository)
		{
			_cartItemRepository = cartItemRepository;
			_shoppingCartRepository = shoppingCartRepository;
		}

		public async Task<bool> AddCartItemToShoppingCartAsync(IProductDto product, ShoppingCartEntity shoppingCart)
		{
			if (product != null && shoppingCart != null)
			{
				var newCartItem = IProductToCartItemFactory.ConvertFromProductToEntity(product);

				newCartItem.ShoppingCartId = shoppingCart.Id;
				newCartItem.ShoppingCartEntity = shoppingCart;

				var result = await _cartItemRepository.CreateCartItemAsync(newCartItem);

				if (result != null)
					return true;
			}
			return false;
		}


		public async Task<List<CartItemEntity>> GetAllCartItemsAsync(IProductDto product, int shoppingCartId)
		{
			if (shoppingCartId >= 0)
			{
				var list = await _cartItemRepository.GetCartItemsAsync(shoppingCartId);

				return list;



			}
			return null!;
		}

		/// <summary>
		/// Checks an item in shoppingcart if it exists and updates it, if quantity increased
		/// </summary>
		/// <param name="list"></param>
		/// <param name="product"></param>
		/// <returns>returns updated cartItemEntity</returns>
		public async Task<CartItemEntity> CheckExistingCartForItems(List<CartItemEntity> list, ProductDto product)
		{
			foreach (var item in list)
			{
				if (item.ProductId == product.ProductId)
				{
					var newEntity = new CartItemEntity();

					newEntity = item;
					newEntity.Quantity += product.Quantity;

					var updatedEntity = await _cartItemRepository.UpdateCartItemAsync(item, newEntity);

					return updatedEntity;
				}
			}
			return null!;

		}

	
		/// <summary>
		///
		/// </summary>
		/// <param name="list"></param>
		/// <param name="product"></param>
		/// <returns>returns updated cartItemEntity</returns>
		public async Task<bool> DeleteCartItemFromShoppingCart(List<CartItemEntity> list, ProductDto product)
		{
			foreach (var item in list)
			{
				if (item.ProductId == product.ProductId)
				{
					var newEntity = new CartItemEntity();

					newEntity = item;
					if (newEntity.Quantity > product.Quantity)
					{
						newEntity.Quantity -= product.Quantity;
						var updatedEntity = await _cartItemRepository.UpdateCartItemAsync(item, newEntity);
						return true;
					}
					else
					{
						if (await DeleteCartItemFromShoppingCart(item))
						{
							// vad ska man returnera food for thought

							return true;
						}							
					}
				}
			}
			return false!;

		}


		/// <summary>
		/// Removes the CartItemEntity from the Shoppingcart
		/// </summary>
		/// <param name="cartItem"></param>
		/// <returns>true if success</returns>
		public async Task<bool> DeleteCartItemFromShoppingCart(CartItemEntity cartItem)
		{
			if(cartItem != null)
			{
				var result =  await _cartItemRepository.DeleteCartItemAsync(cartItem);
				if (result)
				{
					return true;
				}			
			}
			return false;
		}

		
	}


}
