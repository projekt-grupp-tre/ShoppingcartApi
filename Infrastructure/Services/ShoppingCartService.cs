using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCartEntity> GetShoppingcartAsync(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var shoppingcart = await _shoppingCartRepository.GetShoppingCartFromDbAsync(userId);
                return shoppingcart;
            }
            return null!;
        }


        public async Task<ShoppingCartEntity> CreateShoppingCartAsync(string userId)
        {
            var newCart = ShoppingCartFactory.CreateShoppingCartEntity(userId);
            var created = await _shoppingCartRepository.CreateShoppingCartAsync(newCart);

            if (created != null)
                return created;

            return null!;
        }


    }
}
