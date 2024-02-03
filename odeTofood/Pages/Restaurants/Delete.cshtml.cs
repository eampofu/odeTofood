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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantdata;
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantdata)
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
        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantdata.Delete(restaurantId);
            restaurantdata.Commit();
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{restaurant.Name} Deleted successfully";
            return RedirectToPage("./List");
        }
    }
}
