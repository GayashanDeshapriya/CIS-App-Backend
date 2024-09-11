using System.ComponentModel.DataAnnotations;

namespace LogixCIS.Auth.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Salt { get; set; }

        
    }
}
