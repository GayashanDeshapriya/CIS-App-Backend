using LogixCIS.Auth.API.Models;

namespace LogixCIS.Auth.API.Repositories
{
    public interface IAuthRepository
    {
        Task<IEnumerable<User>> GetUsersByUserName(string userName);
    }
}
