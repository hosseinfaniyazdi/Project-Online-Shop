using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectNA.Core.Convertors;
using ProjectNA.Core.DTOs.Clothes;
using ProjectNA.Core.Generator;
using ProjectNA.Core.Security;
using ProjectNA.Core.Services.Interfaces;
using ProjectNA.DataLayer.Context;
using ProjectNA.DataLayer.Entities.Clothing;

namespace ProjectNA.Core.Services
{
    public class ClothingService : IClothingService
    {
        private ShoppingNaContext _context;

        public ClothingService(ShoppingNaContext context)
        {
            _context = context;
        }

        public List<ClothingGroup> GetAllGroup()
        {
            return _context.ClothingGroups.ToList();
        }

        public List<SelectListItem> GetGroupForManageCourse()
        {
            return _context.ClothingGroups.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageClotheing(int groupId)
        {
            return _context.ClothingGroups.Where(g => g.ParentId == groupId)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetStatues()
        {
            return _context.ClothingStatuses.Select(s => new SelectListItem()
            {
                Value = s.StatusId.ToString(),
                Text = s.StatusTitle
            }).ToList();
        }

        public List<ShowClothesForAdminViewModel> GetClothesForAdmin()
        {
            return _context.Clothings.Select(c => new ShowClothesForAdminViewModel()
            {
                ClothingId = c.ClothingId,
                ImageName = c.ClothingImageName,
                Title = c.ClothingTitle
            }).ToList();
        }

        public int AddClothes(Clothing clothing, IFormFile imgClothes)
        {
            clothing.CreateDate = DateTime.Now;
            clothing.ClothingImageName = "no-photo.jpg";
            //TODO Check Image
            if (imgClothes != null && imgClothes.IsImage())
            {
                clothing.ClothingImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgClothes.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Clothes/image",
                    clothing.ClothingImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgClothes.CopyTo(stream);
                }

                ImageConvertor imgresize = new ImageConvertor();
                string thumbpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Clothes/thumb",
                    clothing.ClothingImageName);
                imgresize.Image_resize(imagePath, thumbpath, 150);
            }



            _context.Add(clothing);
            _context.SaveChanges();

            return clothing.ClothingId;
        }

        public Clothing GetCourseById(int clothingId)
        {
            return _context.Clothings.Find(clothingId);
        }

        public void UpdateCourse(Clothing clothing, IFormFile imgClothing)
        {
            clothing.UpdateDate = DateTime.Now;

            if (imgClothing != null && imgClothing.IsImage())
            {
                if (clothing.ClothingImageName != "no-photo.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Clothes/image",
                        clothing.ClothingImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Clothes/thumb",
                        clothing.ClothingImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }

                clothing.ClothingImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgClothing.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Clothes/image",
                    clothing.ClothingImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgClothing.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Clothes/thumb",
                    clothing.ClothingImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }


            _context.Clothings.Update(clothing);
            _context.SaveChanges();
        }

        public Tuple<List<ShowCLothesListItemViewModel>, int> GetClothes(int pageId = 1, string filter = "",
            string orderByType = "date", int startPrice = 0, int endPrice = 0,
            List<int> selectedGroups = null, int take = 0)
        {
            if (take == 0)
                take = 8;

            IQueryable<Clothing> result = _context.Clothings;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.ClothingTitle.Contains(filter));
            }


            switch (orderByType)
            {
                case "date":
                {
                    result = result.OrderByDescending(c => c.CreateDate);
                    break;
                }
                case "updatedate":
                {
                    result = result.OrderByDescending(c => c.UpdateDate);
                    break;
                }
            }

            if (startPrice > 0)
            {
                result = result.Where(c => c.ClothingPrice > startPrice);
            }

            if (endPrice > 0)
            {
                result = result.Where(c => c.ClothingPrice < startPrice);
            }


            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(c => c.GroupId == groupId || c.SubGroup == groupId);
                }
            }

            int skip = (pageId - 1) * take;

            int pageCount = result.Select(c => new ShowCLothesListItemViewModel()
            {
                CLothingId = c.ClothingId,
                ImageName = c.ClothingImageName,
                Price = c.ClothingPrice,
                Title = c.ClothingTitle
            }).Count() / take;

            var query = result.Select(c => new ShowCLothesListItemViewModel()
            {
                CLothingId = c.ClothingId,
                ImageName = c.ClothingImageName,
                Price = c.ClothingPrice,
                Title = c.ClothingTitle
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public Clothing GetClothesForShow(int clothesId)
        {
            return _context.Clothings
                .Include(c => c.ClothingStatuskClothingStatus).Include(c => c.ClothingGroup)
                .Include(c => c.ClothingGroups)
                .FirstOrDefault(c => c.ClothingId == clothesId);
        }

        public void AddComment(ClothingComment comment)
        {
            _context.ClothingComments.Add(comment);
            _context.SaveChanges();
        }

        public Tuple<List<ClothingComment>, int> GetClothingComment(int clothesId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = _context.ClothingComments.Count(c => !c.IsDelete && c.ClothingId == clothesId) / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            return Tuple.Create(
                _context.ClothingComments.Include(c => c.User).Where(c => !c.IsDelete && c.ClothingId == clothesId).Skip(skip).Take(take)
                    .OrderByDescending(c => c.CreateDate).ToList(), pageCount);
        }
    }
}