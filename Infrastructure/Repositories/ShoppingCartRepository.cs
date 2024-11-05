using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class ShoppingCartRepository : IShoppingCartRepository
	{
		private readonly DataContext _dataContext;
		public ShoppingCartRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ShoppingCartEntity> GetShoppingCartAsync(ShoppingCartEntity entity)
		{
			try
			{
				if (entity != null)
				{
					var shoppingCartExists = await _dataContext.ShoppingCarts.FindAsync(entity.UserId);
					if (shoppingCartExists != null)
					{
						return shoppingCartExists;
					}
				}
				else
					return entity;

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);

				throw;
			}

			return null;
		}

		public async Task<ShoppingCartEntity> CreateShoppingCartAsync(ShoppingCartEntity entity)
		{
			try
			{
				if (entity != null)
				{
					var exist = GetShoppingCartAsync(entity);
					return entity;
				}
				else
				{
					ShoppingCartEntity newEntity = new ShoppingCartEntity();
					newEntity.UserId = entity.UserId;
					newEntity.Quantity = entity.Quantity;


					_dataContext.ShoppingCarts.Entry(newEntity);
					_dataContext.SaveChangesAsync();
					return newEntity;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}

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
