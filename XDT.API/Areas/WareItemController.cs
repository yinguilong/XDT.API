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
        [Route("/shangpin/prices")]
        public IActionResult PriceItems(RequestEntity<BoxItemDTO> reqEntity)
        {
            if (reqEntity.Count != reqEntity.Items.Count() && reqEntity.Count != 1)
            {
                return Json(new ResponseEntity<BoxItemDTO>() { Result = false });
            }
            var ppismItem = reqEntity.Items.Single();
            var priceItems = _wareItemServiceImp.GetPriceItemsByWareItem(ppismItem.WareItemId);
            var responseModel = new ResponseEntity<PriceItemDTO>()
            {
                Result = true,
                Items = priceItems,
                Count = priceItems == null ? 0 : priceItems.Count
            };
            return Json(responseModel);//
        }
        [Route("/shangpin/mybox")]
        public IActionResult GetMyBoxItems(RequestEntity<BoxItemDTO> reqEntity)
        {
            if (reqEntity.Count != reqEntity.Items.Count() && reqEntity.Count != 1)
            {
                return Json(new ResponseEntity<BoxItemDTO>() { Result = false });
            }
            var boxItem = reqEntity.Items.Single();
            var boxItems = _boxItemServiceImp.GetBoxItemsByUserId(boxItem.UserId, (byte)boxItem.Trend, boxItem.PageIndex ?? 1, boxItem.PageSize ?? 6);
            var responseModel = new ResponseEntity<BoxItemDTO>()
            {
                Result = true,
                Items = boxItems,
                Count = boxItems == null ? 0 : boxItems.Count
            };
            return Json(responseModel);//
        }
    }
}
