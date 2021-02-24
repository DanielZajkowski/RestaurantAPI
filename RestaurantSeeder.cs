using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        private RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<RestaurantDto> GetRestaurants()
        {
            var restaurants = new List<RestaurantDto>()
            {
                new RestaurantDto()
                {
                    Name = "KFC",
                    Category = "Yes",
                    Description = "To eat",
                    //ContactEmail = "email",
                    HasDelivery = true,
                    //Dishes = new List<Dish>()
                    //{
                    //    new Dish()
                    //    {
                    //        Name = "food",
                    //        Price = 1.2M
                    //    }
                    //},
                    //Address = new Address()
                    //{
                    //    City = "Krk",
                    //    Street = "Dg",
                    //    PostalCode = "30"
                    //}
                }
            };
            return restaurants;
        }
    }
}
