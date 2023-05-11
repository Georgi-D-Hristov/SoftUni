namespace Fluffy_Duffy_Munchkin_Cats_WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CatController : Controller
    {
        public IActionResult Add() 
        {
            return View();
        }
    }
}
