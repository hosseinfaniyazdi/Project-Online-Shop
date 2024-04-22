using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectNA.Core.Services.Interfaces;

namespace ProjectNA.Web.ViewComponents
{
    public class ClothingGroupComponent : ViewComponent
    {
        private IClothingService _clothing;

        public ClothingGroupComponent(IClothingService clothingService)
        {
            _clothing = clothingService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ClothingGroup", _clothing.GetAllGroup()));
        }
    }
}