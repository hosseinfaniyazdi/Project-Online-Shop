using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectNA.Core.DTOs.Clothes;
using ProjectNA.DataLayer.Entities.Clothing;

namespace ProjectNA.Core.Services.Interfaces
{
    public interface IClothingService
    {
        #region Group

        List<ClothingGroup> GetAllGroup();
        List<SelectListItem> GetGroupForManageCourse();
        List<SelectListItem> GetSubGroupForManageClotheing(int groupId);
        List<SelectListItem> GetStatues();
        #endregion

        #region Clothes

        List<ShowClothesForAdminViewModel> GetClothesForAdmin();

        int AddClothes(Clothing clothing, IFormFile imgClothes);
        Clothing GetCourseById(int clothingId);
        void UpdateCourse(Clothing clothing, IFormFile imgClothing);

        Tuple<List<ShowCLothesListItemViewModel>, int> GetClothes(int pageId = 1, string filter = "",
            string orderByType = "date", int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null,
            int take = 0);

        Clothing GetClothesForShow(int clothesId);

        #endregion

        #region Comment


        void AddComment(ClothingComment comment);
        Tuple<List<ClothingComment>, int> GetClothingComment(int clothesId, int pageId = 1);

        #endregion
    }
}