﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace XDT.API.Areas.Home
{
    public class HomeController : BaseController
    {
        // GET: /<controller>/
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Power By Yin.Jia.Li");
        }
    }
}
