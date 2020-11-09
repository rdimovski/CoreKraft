﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ccf.Ck.SysPlugins.Recorders.Postman.Models
{
    public class PostmanRequest
    {
        public string Name { get; set; }

        [JsonProperty("request")]
        public RequestContent RequestContent { get; set; }
        public List<string> Response { get; set; } = new List<string>() { string.Empty };
    }
}
