using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories
{
	public class CartItemRepository : ICartItemRepository
	{
		private readonly DataContext _dataContext;
		private readonly IShoppingCartRepository _shoppingCart;
		public CartItemRepository(DataContext dataContext, IShoppingCartRepository shoppingCart)
		{
			_dataContext = dataContext;
			_shoppingCart = shoppingCart;

		}

		public async Task<CartItemEntity> CreateCartItemAsync(CartItemEntity entity)
		{
			try
			{
				if (entity != null)
				{
					_dataContext.CartItems.Add(entity);
					await _dataContext.SaveChangesAsync();
					return entity;
				}
			}
			catch (Exception ex) { Debug.WriteLine($"CreateCartItemAsync - Repository ::: {ex.Message}"); }
			return null!;
		}


		public async Task<List<CartItemEntity>> GetCartItemsAsync(int shoppingCartId)
		{
			try
			{
				if (shoppingCartId >= 0)
				{
					var result = await _dataContext.CartItems.Where<CartItemEntity>(x => x.ShoppingCartId == shoppingCartId).ToListAsync();

					return result;
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine("GetCartItemsAsync :: " + ex.Message);
			}
			return null!;
		}



		public async Task<CartItemEntity> UpdateCartItemAsync(CartItemEntity oldEntity, CartItemEntity newEntity)
		{
			try
			{
				if (oldEntity != null && newEntity != null)
				{
					_dataContext.CartItems.Entry(oldEntity).CurrentValues.SetValues(newEntity);
					await _dataContext.SaveChangesAsync();
					return newEntity;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return null!;
		}

		public async Task<bool> DeleteCartItemAsync(CartItemEntity cartItem)
		{
			try
			{
				if (cartItem != null)
				{
					_dataContext.CartItems.Remove(cartItem);
					await _dataContext.SaveChangesAsync();
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			
			}
			return false;
		}
	}
}


