﻿using System;

namespace Dotnet5.GraphQL3.Store.Services.Models.Messages
{
    public class ReviewMessage
    {
        public string Title { get; set; }
        public Guid ProductId { get; set; }
    }
}