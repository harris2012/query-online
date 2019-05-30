using Newtonsoft.Json;
using Savory.QueryOnline.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Controllers.Response
{
    public class ServerItemsResponse : ResponseBase
    {
        [JsonProperty("servers")]
        public List<ServerVo> ServerList { get; set; }
    }
}