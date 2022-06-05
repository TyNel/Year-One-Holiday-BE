using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Year_One.Services.CommonMethods;
using Year_One.Services.Interfaces;
using YearOne.Models.Entities;
using YearOne.Models.Requests;

namespace Year_One.Services
{
    public class CookieService : ICookieService
    {
        private readonly IConfiguration _config;

        FullCookie _cookie = new FullCookie();
        User _user = new User();
        Recipe _recipe = new Recipe();
        RecipeLiked _liked = new RecipeLiked();
        FullRecipe _fullrecipe = new FullRecipe();

        public CookieService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Default"));
            }
        }

        public async Task<IEnumerable<FullCookie>> GetCookieTypes()
        {
          
            using (IDbConnection dbConnection = Connection)
            {

                var results = await Connection.QueryAsync<FullCookie>("[dbo].[GetCookies]", commandType: CommandType.StoredProcedure);

                return results;

            }
        }

        public async Task<int> AddUser(UserAddRequest user)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[CreateUser]";
                var parameter = new DynamicParameters();

                parameter.Add("userId", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@FirstName", user.FirstName);
                parameter.Add("@LastName", user.LastName);
                parameter.Add("@Email", user.Email);
                parameter.Add("@Password", PwManager.Encrypt(user.Password));

                await Connection.QueryAsync<int>(proc, parameter, commandType: CommandType.StoredProcedure);

                int newIdentity = parameter.Get<int>("@userId");

                return newIdentity;
            }
        }

        public async Task<User> Login(UserLogin loginRequest)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[UserLogin]";
                var parameter = new DynamicParameters();

                parameter.Add("@Email", loginRequest.Email);
                parameter.Add("@Password", PwManager.Encrypt(loginRequest.Password));

                var response = await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                _user = response.FirstOrDefault();

                return _user;
            }
        }

        public async Task<FullCookie> AddCookie(CookieAddRequest cookieRequest)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[InsertCookie]";
                var parameter = new DynamicParameters();

                parameter.Add("@CookieName", cookieRequest.CookieName);
                parameter.Add("@CookieImageUrl", cookieRequest.CookieImageUrl);

                var response = await Connection.QueryAsync<FullCookie>(proc, parameter, commandType: CommandType.StoredProcedure);

                _cookie = response.FirstOrDefault();

                return _cookie;

            }
        }

        public async Task<Recipe> AddRecipe(RecipeAddRequest recipeRequest)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[InsertRecipe]";
                var parameter = new DynamicParameters();

                parameter.Add("@CookieType", recipeRequest.CookieType);
                parameter.Add("@Url", recipeRequest.Url);
                parameter.Add("@Description", recipeRequest.Description);
                parameter.Add("@WebsiteName", recipeRequest.WebsiteName);

                var response = await Connection.QueryAsync<Recipe>(proc, parameter, commandType: CommandType.StoredProcedure);

                _recipe = response.FirstOrDefault();

                return _recipe;

            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipe(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[GetRecipes]";

                var response = await Connection.QueryAsync<Recipe>(proc, new { id }, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<RecipeLiked> LikedRecipe(UserLikedRecipe recipeLikeRequest)
        {
            
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[UserLike]";
                var parameter = new DynamicParameters();

                parameter.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@likeParentId", recipeLikeRequest.LikeParentId);
                parameter.Add("@UserId", recipeLikeRequest.UserId);
                parameter.Add("@isLike", recipeLikeRequest.IsLike);

                var response = await Connection.QueryAsync<RecipeLiked>(proc, parameter, commandType: CommandType.StoredProcedure);

                return response.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<RecipeLiked>> GetLikes(int id)
        {
           
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[GetRecipeLikes]";

                var response = await Connection.QueryAsync<RecipeLiked>(proc, new { id }, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            _user = new User();

            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[GetEmail]";

                var user = await Connection.QueryAsync<User>(proc, new { email }, commandType: CommandType.StoredProcedure);

                _user = user.FirstOrDefault();


                return _user;

            }
        }

        public async Task<User> UpdatePassword(PasswordUpdateRequest userRequest)
        {
            _user = new User();

            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[UpdatePassword]";
                var parameter = new DynamicParameters();

                parameter.Add("@userId", userRequest.UserId);
                parameter.Add("@password", PwManager.Encrypt(userRequest.Password));

                var user = await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                _user = user.FirstOrDefault();

                return _user;
            }
        }

       
    }
}
