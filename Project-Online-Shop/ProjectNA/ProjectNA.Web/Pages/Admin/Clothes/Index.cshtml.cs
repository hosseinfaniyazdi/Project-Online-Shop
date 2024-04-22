using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectNA.Core.DTOs.Clothes;
using ProjectNA.Core.Services.Interfaces;

namespace ProjectNA.Web.Pages.Admin.Clothes
{
    public class IndexModel : PageModel
    {
        private IClothingService _clothingService;

        public IndexModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        public List<ShowClothesForAdminViewModel> ShowClothesForAdminViewModels { get; set; }
        public void OnGet()
        {
            ShowClothesForAdminViewModels = _clothingService.GetClothesForAdmin();
        }
    }
}
