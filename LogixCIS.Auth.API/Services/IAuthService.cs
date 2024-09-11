namespace LogixCIS.Auth.API.Services;
using LogixCIS.Auth.API.Models;


public interface IAuthService
{
    Task<ResponseModel> Login(Login loginData);
}
