using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User1
{
    public int Id { get; set; }
    //[StringLength(20, ErrorMessage = "password length must be between 5-20", MinimumLength = 5)]
    public string Password { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }
  //[EmailAddress(ErrorMessage = "Email not valid")]
    public string Email { get; set; } = null!;
}
