using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Vo
{
    public class SchemaTableVo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}