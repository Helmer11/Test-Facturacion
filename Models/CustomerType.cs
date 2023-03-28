﻿using System;
using System.Collections.Generic;

namespace Test_Schad.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
