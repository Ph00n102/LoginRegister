using System;
using System.Collections.Generic;

namespace DotnetStockApi.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public int Categorystatus { get; set; }
}
