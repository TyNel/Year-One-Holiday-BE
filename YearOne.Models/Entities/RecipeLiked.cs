using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Entities
{
    public class RecipeLiked
    {
        public int LikeParentId { get; set; }
        public int IsLike { get; set; }
        public int UserId { get; set; }

    }
}
