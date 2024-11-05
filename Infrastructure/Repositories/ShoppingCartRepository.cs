using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories
{
	public class ShoppingCartRepository : IShoppingCartRepository
	{
		private readonly DataContext _dataContext;
		public ShoppingCartRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ShoppingCartEntity> GetShoppingCartFromDbAsync(string userId)
		{
			try
			{
				if (!string.IsNullOrEmpty(userId))
				{
					var shoppingCartExists = await _dataContext.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
					if (shoppingCartExists != null)
					{
						return shoppingCartExists;
					}
				}
			}
			catch (Exception ex){ Debug.WriteLine($"GetShoppingCartAsync - Repository ::: {ex.Message}"); }
			return null!;
		}

		public async Task<ShoppingCartEntity> CreateShoppingCartAsync(ShoppingCartEntity entity)
		{
			try
			{
				if (entity != null)
				{
					var exist = await GetShoppingCartFromDbAsync(entity.UserId!);

					if (exist == null) 
					{
                        _dataContext.ShoppingCarts.Add(entity);
                        await _dataContext.SaveChangesAsync();

						return entity;
                    }

					return exist!;
				}
			}
			catch (Exception ex){ Debug.WriteLine($"CreateShoppingCartAsync - Repository ::: {ex.Message}"); }
			return null!;
		}

		public Task<ShoppingCartEntity> DeleteShoppingCartAsync(ShoppingCartEntity entity)
		{
			throw new NotImplementedException();
		}

		public Task<ShoppingCartEntity> UpdateShoppingCartAsync(ShoppingCartEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
