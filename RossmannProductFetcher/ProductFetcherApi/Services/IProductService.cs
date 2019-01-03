﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFetcherApi.Services
{
    public interface IProductService
    {
        Task<BsonDocument> GetProductById(int id);
    }
}
