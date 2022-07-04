using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoWebApp.Models;
using VideoWebApp.ViewModels.Shared;



namespace VideoWebApp.Controllers
{
    public class HomeController : ControllerWithBaseLogic
    {

        public HomeController(ILogger<HomeController> logger)
        {
            
        }

        public IActionResult Index() // main page, where videos
        {    
            return View();
        }

        

        
    }
}
