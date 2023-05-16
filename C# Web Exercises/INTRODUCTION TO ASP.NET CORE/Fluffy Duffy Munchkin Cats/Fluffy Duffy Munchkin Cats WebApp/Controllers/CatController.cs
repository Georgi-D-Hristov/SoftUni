namespace Fluffy_Duffy_Munchkin_Cats_WebApp.Controllers
{
    using Fluffy_Duffy_Munchkin_Cats_WebApp.Models.Cat;
    using Microsoft.AspNetCore.Mvc;

    public class CatController : Controller
    {
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCatFormModel cat)
        { 
            if(!ModelState.IsValid) 
            {
                return View("/Error");
            }

            //var newCat = new Cat

            return View(cat);
        }
    }
}
