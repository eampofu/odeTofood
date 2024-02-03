using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odeTofood.Core;
using odeTofood.Data;

namespace odeTofood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantdata;

        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantdata)
        {
            this.restaurantdata = restaurantdata;
        }
        public void OnGet(int restuarantId)
        {
            Restaurant = restaurantdata.GetById(restuarantId);
        }
    }
}
