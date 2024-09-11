using LogixCIS.Auth.API.Models;
using LogixCIS.Auth.API.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LogixCIS.Auth.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository AuthRepository;
        private readonly IConfiguration config;

        public AuthService(IAuthRepository authRepository, IConfiguration config)
        {
            AuthRepository = authRepository;
            this.config = config;
        }

        public async Task<ResponseModel> Login(Login logindata)
        {
            try
            {
                User? matchedUser = null;
                var users = await AuthRepository.GetUsersByUserName(logindata.UserName);

                foreach (var user in users)
                {
                    var hashedPassword = GetHashToMatchLoginPassword(logindata.Password, user.Salt);

                    if (user.Password.Equals(hashedPassword))
                    {
                        matchedUser = user;
                        break;
                    }
                }

                if (matchedUser == null)
                {
                    return new ResponseModel() { Status = false, Message = "Password or user name does not match.", Result = null };
                }

                return new ResponseModel() { Status = true, Message = "Login Success.", Result = GenerateJwtToken(matchedUser) };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = false, Message = "Error." + ex.Message, Result = null };
            }
        }

        private string GetHashToMatchLoginPassword(string password, string salt)
        {
            byte[] saltAsByte = Convert.FromBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashedValue = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                    password: password,
                                    salt: saltAsByte,
                                    prf: KeyDerivationPrf.HMACSHA256,
                                    iterationCount: 100000,
                                    numBytesRequested: 256 / 8));

            return hashedValue;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
