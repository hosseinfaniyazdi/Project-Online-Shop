using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectNA.DataLayer.Entities.Order;

namespace ProjectNA.DataLayer.Entities.Clothing
{
    public class Clothing
    {
        [Key]
        public int ClothingId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Display(Name = "عنوان لباس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ClothingTitle { get; set; }

        [Display(Name = "مشخصات لباس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ClothingDescription { get; set; }

        [Display(Name = "قیمت لباس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ClothingPrice { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ClothingImageName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        #region Relations

        [ForeignKey("GroupId")]
        public ClothingGroup ClothingGroup { get; set; }

        [ForeignKey("SubGroup")]
        public ClothingGroup ClothingGroups { get; set; }

        [ForeignKey("StatusId")]
        public ClothingStatus ClothingStatuskClothingStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ClothingComment> ClothingComments { get; set; }

        #endregion
    }
}