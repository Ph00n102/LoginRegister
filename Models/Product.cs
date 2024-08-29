using System;
using System.Collections.Generic;

namespace DotnetStockApi.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string? Productname { get; set; }

    public decimal? Unitprice { get; set; }

    public int? Unitinstock { get; set; }

    public string? Productpicture { get; set; }

    public int Categoryid { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }
}
