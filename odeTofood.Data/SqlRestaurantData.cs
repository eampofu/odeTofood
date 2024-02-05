using Microsoft.EntityFrameworkCore;
using odeTofood.Core;
using System.Collections.Generic;
using System.Linq;

namespace odeTofood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly odeTofoodDbContext db;

        public SqlRestaurantData(odeTofoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant!=null)

            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name  
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = db.Restaurants.Attach(updateRestaurant);
            entity.State =  EntityState.Modified;
            return updateRestaurant;
        }
    }
}
