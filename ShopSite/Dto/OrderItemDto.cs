using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class OrderItemDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quntity { get; set; }
  
}
