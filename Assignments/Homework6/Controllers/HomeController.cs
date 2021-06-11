//CSHP320A
//Frederick J. Skaggs - Homework 6

using Homework6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CardModel());
        }

        [HttpPost]
        public IActionResult Index(CardModel cardModel)
        {
            if (ModelState.IsValid)
            {
                return View("BDayCard", cardModel);
            }
            else
            {
                return View(cardModel);
            }
        }
    }
}
