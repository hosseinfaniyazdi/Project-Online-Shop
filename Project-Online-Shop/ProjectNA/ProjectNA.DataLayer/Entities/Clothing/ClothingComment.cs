using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectNA.DataLayer.Entities.Clothing
{
    public class ClothingComment
    {
        [Key]
        public int CommentId { get; set; }
        public int ClothingId { get; set; }
        public int UserId { get; set; }

        [MaxLength(700)]
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdminRead { get; set; }


        public Clothing Clothing { get; set; }
        public User.User User { get; set; }
    }
}