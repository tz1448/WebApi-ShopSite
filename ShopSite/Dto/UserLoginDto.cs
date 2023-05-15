using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class UserLoginDto
    {
        [StringLength(20)]
        public string Password { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; } = null!;

    }
}
