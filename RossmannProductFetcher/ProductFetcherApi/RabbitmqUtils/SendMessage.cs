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
        public JObject Data { get; set; }
        public SendMessage(JObject message)
        {
            Data = message;
        }
    }
}
