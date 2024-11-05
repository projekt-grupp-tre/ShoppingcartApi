using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System.Diagnostics;

namespace Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DataContext _dataContext;
        private readonly IShoppingCartRepository _shoppingCart;
        public CartItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
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
            catch (Exception ex){ Debug.WriteLine($"CreateCartItemAsync - Repository ::: {ex.Message}"); }
            return null!;
        }




        //public Task<CartItemEntity> CreateCartItemAsync(IProductDto productDto)
        //{
        //	var entity = _IProductToCartItemFactory.ConvertFromProductToEntity(productDto);

        //	_dataContext.AddAsync(entity);
        //	_dataContext.SaveChangesAsync();
        //	return entity;
        //}
    }
}
