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
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantdata.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
