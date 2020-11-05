﻿using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public class KayakModel : ProductModel
    {
        public int AmountOfPerson { get; set; }
        public KayakType Type { get; set; }
    }
}