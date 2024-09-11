using LogixCIS.Auth.API.Data;
using LogixCIS.Auth.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;


namespace LogixCIS.Auth.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext DbContext;
        private readonly IConfiguration config;

        public AuthRepository(DataContext context, IConfiguration config)
        {
            DbContext = context;
            this.config = config;
            
        }
        public async Task<IEnumerable<User>>GetUsersByUserName(string userName)
        {
            try
            {
                using IDbConnection conn = new SqlConnection(config.GetConnectionString("DefaultConnection"));
                return await conn.QueryAsync<User>("GL.spGetUsersByUserName", new { userName }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
