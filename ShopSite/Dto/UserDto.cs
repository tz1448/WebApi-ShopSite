using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO;

public partial class UserDto
{
    public int Id { get; set; }
    
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }
  
    [EmailAddress(ErrorMessage = "Email not valid")]
    public string Email { get; set; } = null!;


}
