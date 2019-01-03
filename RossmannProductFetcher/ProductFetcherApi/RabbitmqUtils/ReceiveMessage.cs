using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFetcherApi.RabbitmqUtils
{
    public class ReceiveMessage : IMessage
    {
        public JObject Data { get; set; }
        public ReceiveMessage(JObject message)
        {
            Data = message;
        }
    }
}
