using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectNA.Core.Services.Interfaces;
using ProjectNA.DataLayer.Entities.Clothing;

namespace ProjectNA.Web.Pages.Admin.Clothes
{
    public class EditClothessModel : PageModel
    {
        private IClothingService _clothingService;

        public EditClothessModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [BindProperty]
        public Clothing Clothing { get; set; }
        public void OnGet(int id)
        {
            Clothing = _clothingService.GetCourseById(id);

            var groups = _clothingService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text", Clothing.GroupId);

            var subGrous = _clothingService.GetSubGroupForManageClotheing(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGrous, "Value", "Text", Clothing.SubGroup ?? 0);

            var statues = _clothingService.GetStatues();
            ViewData["Statues"] = new SelectList(statues, "Value", "Text", Clothing.StatusId);
        }
        public IActionResult OnPost(IFormFile imgClothingUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _clothingService.UpdateCourse(Clothing, imgClothingUp);

            return RedirectToPage("Index");
        }
    }
}
