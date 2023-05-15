using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class OrderDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Ordersum { get; set; }

    public virtual UserDto User { get; set; } = null!;


}
