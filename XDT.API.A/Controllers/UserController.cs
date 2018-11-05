using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XDT.Model.Contracts;
using XDT.Model.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XDT.API.A.Controllers
{
    [Route("/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userServiceImp;
        private readonly IBoxItemService _boxItemServiceImp;
        public UserController(IUserService userServiceImp,IBoxItemService boxItemServiceImp)
        {
            _userServiceImp = userServiceImp;
            _boxItemServiceImp = boxItemServiceImp;
        }
        [HttpPost]
        // GET: /<controller>/
        [Route("/register")]
        public IActionResult ReisterUser(RequestEntity<UserDTO> reqEntity)
        {
            if (reqEntity == null || reqEntity.Count != reqEntity.Items.Count())
            {
                return Json(new ResponseEntity<UserDTO>() { Result = false });
            }
            var userDtos = reqEntity.Items.ToList();
            var registUsers = _userServiceImp.CreateUsers(userDtos);
            var responseModel = new ResponseEntity<UserDTO>()
            {
                Result = (registUsers != null && registUsers.Any()),
                Items = registUsers,
                Count = registUsers == null ? 0 : registUsers.Count
            };
            return Json(responseModel);//
        }
        [HttpPost]
        [Route("/validateuser")]
        public IActionResult ValidateUser(RequestEntity<UserDTO> reqEntity)
        {
            if (reqEntity == null || reqEntity.Items == null || reqEntity.Count != reqEntity.Items.Count())
            {
                return Json(new ResponseEntity<UserDTO>() { Result = false });
            }
            var userDto = reqEntity.Items.ToList().FirstOrDefault();
            var user = _userServiceImp.ValidateUser(userDto.LoginAccount, userDto.Password);
            var users = new List<UserDTO>();
            if (user != null)
            {
                user.Password = string.Empty;//隐藏用户密码
                users.Add(user);
            }
            var responseModel = new ResponseEntity<UserDTO>()
            {
                Result = user != null,
                Count = users.Count,
                Items = users
            };
            return Json(responseModel);
        }
        [HttpPost]
        [Route("/my")]
        public IActionResult GetMy(RequestEntity<UserDTO> reqEntity)
        {
            if (reqEntity.Count != reqEntity.Items.Count() && reqEntity.Count != 1)
            {
                return Json(new ResponseEntity<UserDTO>() { Result = false });
            }
            var userDto = reqEntity.Items.Single();
            var userDtoRes = _userServiceImp.GetUserByLoginAccount(userDto.LoginAccount);
            var userDtoResList = new List<UserDTO>();
            if (userDtoRes != null) userDtoResList.Add(userDtoRes);
            var responseModel = new ResponseEntity<UserDTO>()
            {
                Result = true,
                Items = userDtoResList,
                Count = userDtoRes == null ? 0 : 1
            };
            return Json(responseModel);//
        }
    }
}
