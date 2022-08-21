using Business.Absrtact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
    
    
    public class HomeController : ControllerBase
    {
   
        public HomeController()
        {
            
        }
        [HttpGet]
        public IActionResult Index()
        {
          

            return Ok("Success");
        }

     
    }
}
