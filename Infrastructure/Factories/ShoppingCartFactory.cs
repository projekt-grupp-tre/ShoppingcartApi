using Infrastructure.Entities;

namespace Infrastructure.Factories
{
    public static class ShoppingCartFactory
    {
        public static ShoppingCartEntity CreateShoppingCartEntity(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var cart = new ShoppingCartEntity
                {
                    UserId = userId
                };

                return cart;
            }

            return null!;
        }
    }
}
