using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using odeTofood.Core;
using odeTofood.Data;

namespace odeTofood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public ListModel(IConfiguration config,IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public void OnGet(string searchTerm)
        {

            // message = config["Message"];
           // Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantByName(searchTerm);
            Debug.WriteLine(Restaurants);
        }
    }
}
