using System.ComponentModel.DataAnnotations;

namespace LogixCIS.Auth.API.Models
{
    public class Login
    {
       
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
