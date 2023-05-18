﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Ordersum { get; set; }
    


    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
