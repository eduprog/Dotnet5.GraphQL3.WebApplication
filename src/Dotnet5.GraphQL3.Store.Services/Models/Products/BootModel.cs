﻿using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public class BootModel : ProductModel
    {
        public BootType Type { get; set; }
        public int Size { get; set; }
    }
}