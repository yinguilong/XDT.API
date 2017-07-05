using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XDT.Model.Contracts;
using XDT.Model.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XDT.API.Areas
{
    public class WareItemController : BaseController
    {
        private readonly IUserService _userServiceImp;
        private readonly IBoxItemService _boxItemServiceImp;
        private readonly IWareItemService _wareItemServiceImp;
        public WareItemController(IUserService userService,IBoxItemService boxItemService,IWareItemService wareItemService)
        {
            _userServiceImp = userService;
            _boxItemServiceImp = boxItemService;
            _wareItemServiceImp = wareItemService;
        }
        // GET: /<controller>/
        [Route("/shangpin/add")]
        public IActionResult WareItemAdd(RequestEntity<BoxItemDTO> req)
        {
            if (req.Count != req.Items.Count() && req.Count != 1)
            {
                return Json(new ResponseEntity<WareItemDTO>() { Result = false });
            }
            var boxItems = req.Items.ToList();
            var wareList = _wareItemServiceImp.AddBoxItems(boxItems);
            var responseModel = new ResponseEntity<WareItemDTO>()
            {
                Result = true,
                Items = wareList,
                Count = wareList == null ? 0 : wareList.Count
            };
            return Json(responseModel);
        }
    }
}
