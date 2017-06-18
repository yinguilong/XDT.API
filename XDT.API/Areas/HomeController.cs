using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XDT.API.Areas
{
    public class HomeController : BaseController
    {
        // GET: /<controller>/
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome!!");
        }
    }
}
