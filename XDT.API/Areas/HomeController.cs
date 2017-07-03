using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using XDT.Domain.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XDT.API.Areas
{
    public class HomeController : BaseController
    {
        private IBoxRepository _ppBoxRepository;
        // GET: /<controller>/
        [Route("/")]
        public IActionResult Index()
        {
            
            return Content("Hello World!");
        }
    }
}
