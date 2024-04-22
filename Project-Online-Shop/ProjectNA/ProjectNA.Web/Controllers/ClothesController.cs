using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectNA.Core.Services.Interfaces;
using ProjectNA.DataLayer.Entities.Clothing;

namespace ProjectNA.Web.Controllers
{
    public class ClothesController : Controller
    {
        private IClothingService _clothingService;
        private IOrderService _orderService;
        private IUserService _userService;

        public ClothesController(IClothingService clothingService, IOrderService orderService, IUserService userService)
        {
            _clothingService = clothingService;
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index(int pageId = 1, string filter = ""
            , string orderByType = "date",
            int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null)
        {
            ViewBag.selectedGroups = selectedGroups;
            ViewBag.Groups = _clothingService.GetAllGroup();
            ViewBag.pageId = pageId;
            return View(_clothingService.GetClothes(pageId, filter, orderByType, startPrice, endPrice, selectedGroups, 9));
        }

        [Route("ShowClothes/{id}")]
        public IActionResult ShowClothes(int id)
        {
            var clothes = _clothingService.GetClothesForShow(id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        [Authorize]
        public IActionResult BuyClothes(int id)
        {
            int orderId = _orderService.AddOrder(User.Identity.Name, id);
           return Redirect("/UserPanel/MyOrders/ShowOrder/" + orderId);
        }


        [HttpPost]
        public IActionResult CreateComment(ClothingComment comment)
        {
            comment.IsDelete = false;
            comment.CreateDate = DateTime.Now;
            comment.UserId = _userService.GetUserIdByUserName(User.Identity.Name);
            _clothingService.AddComment(comment);

            return View("ShowComment", _clothingService.GetClothingComment(comment.ClothingId));

        }

        public IActionResult ShowComment(int id, int pageId=1)
        {
            return View(_clothingService.GetClothingComment(id, pageId));
        }
    }
}
