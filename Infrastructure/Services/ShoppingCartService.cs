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

        public async Task<ShoppingCartEntity> GetShoppingcartAsync(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                var shoppingcart = await _shoppingCartRepository.GetShoppingCartFromDbAsync(userEmail);
                return shoppingcart;
            }
            return null!;
        }


        public async Task<ShoppingCartEntity> CreateShoppingCartAsync(string userEmail)
        {
            var newCart = ShoppingCartFactory.CreateShoppingCartEntity(userEmail);
            var created = await _shoppingCartRepository.CreateShoppingCartAsync(newCart);

            if (created != null)
                return created;

            return null!;
        }


    }
}
