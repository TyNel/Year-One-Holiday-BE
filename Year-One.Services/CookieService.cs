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
using Year_One.Services.Interfaces;
using YearOne.Models.Requests;

namespace Year_One.Services
{
    public class CookieService : ICookieService
    {
        private readonly IConfiguration _config;

        Cookie _cookie = new Cookie();

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

        public async Task<IEnumerable<Cookie>> GetCookieTypes()
        {

            using (IDbConnection dbConnection = Connection)
            {
                var result = await Connection.QueryAsync<Cookie>("[dbo].[GetCookies]", commandType: CommandType.StoredProcedure);

                return result;
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
                parameter.Add("@Password", user.Password);

                await Connection.QueryAsync<int>(proc, parameter, commandType: CommandType.StoredProcedure);

                int newIdentity = parameter.Get<int>("@userId");

                return newIdentity;
            }
        }


    }
}
