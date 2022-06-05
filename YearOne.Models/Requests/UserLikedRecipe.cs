using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Requests
{
    public class UserLikedRecipe
    {
        [Required]
        public int LikeParentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0, 1)]
        public int IsLike { get; set; }
    }
}
