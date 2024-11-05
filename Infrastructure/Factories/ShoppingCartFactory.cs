using Infrastructure.Entities;

namespace Infrastructure.Factories
{
    public static class ShoppingCartFactory
    {
        public static ShoppingCartEntity CreateShoppingCartEntity(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                var cart = new ShoppingCartEntity
                {
                    UserEmail = userEmail
                };

                return cart;
            }

            return null!;
        }
    }
}
