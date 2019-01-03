using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFetcherApi.RabbitmqUtils
{
    public class SendMessage : IMessage
    {
        public string Data { get; set; }
        public SendMessage(string message)
        {
            Data = message;
        }
    }
}
