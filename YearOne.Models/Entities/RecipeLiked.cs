using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Entities
{
    public class RecipeLiked
    {
        public int RecipeId { get; set; }

        public int CookieType { get; set; }

        public int UserId { get; set; }

        public byte IsLike { get; set; }

    }
}
