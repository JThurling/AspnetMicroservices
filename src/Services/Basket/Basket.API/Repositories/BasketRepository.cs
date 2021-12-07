using System;
using System.Threading.Tasks;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache;
        }
        
        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _cache.GetStringAsync(username);

            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _cache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.Username);
        }

        public async Task DeleteBasket(string username)
        {
            await _cache.RemoveAsync(username);
        }
    }
}