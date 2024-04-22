using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ProjectNA.DataLayer.Entities.Clothing
{
    public class ClothingStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; }

        [InverseProperty("ClothingStatuskClothingStatus")]
        public List<Clothing> Clothings { get; set; }
    }
}