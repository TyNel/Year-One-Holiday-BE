using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YearOne.Models.Entities;
using YearOne.Models.Requests;

namespace Year_One.Services.Interfaces
{
    public interface ICookieService
    {
        Task<IEnumerable<FullCookie>> GetCookieTypes();

        Task<int> AddUser(UserAddRequest user);

        Task<User> Login(UserLogin loginRequest);

        Task<FullCookie> AddCookie(CookieAddRequest cookieRequest);

        Task<Recipe> AddRecipe(RecipeAddRequest recipeRequest);

        Task<IEnumerable<Recipe>> GetRecipe(int id);

        Task<RecipeLiked> LikedRecipe(UserLikedRecipe recipeLikeRequest);

        Task<IEnumerable<RecipeLiked>> GetLikes(int id);

        Task<User> GetByEmail(string email);

        Task<User> UpdatePassword(PasswordUpdateRequest userRequest);
    }
}
