using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Entities
{
    public class CookieLiked
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int UserId { get; set; }

        public byte IsLike { get; set; }
    }
}
