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
        public int RecipesId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0, 1)]
        public byte isLike { get; set; }
    }
}
