using odeTofood.Core;
using System.Collections.Generic;
using System.Linq;

namespace odeTofood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="Scotts Pizza", Location="Maryland",Cuisine=CuisineType.Indian},
                new Restaurant{Id=2,Name="Cinnamon Club", Location="London",Cuisine=CuisineType.Italian},
                new Restaurant{Id=3,Name="La Costa", Location="California",Cuisine=CuisineType.Mexican},
            };

        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == id);
            if (restaurant!=null)
            {
                restaurants.Remove(restaurant);

            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name=null)
        {
            return from r in restaurants where string.IsNullOrEmpty(name)||r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id==updateRestaurant.Id);
            if (restaurant!=null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Cuisine = updateRestaurant.Cuisine;
                restaurant.Location = updateRestaurant.Location;
            }
            return restaurant;

        }
    }
    
}
