using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class OrderItemDto
{
   public int ProductId { get; set; }

    public int Quntity { get; set; }
  
}
