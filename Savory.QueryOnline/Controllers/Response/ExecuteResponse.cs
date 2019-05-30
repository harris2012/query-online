using Newtonsoft.Json;
using Savory.QueryOnline.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Controllers.Response
{
    public class ExecuteResponse : ResponseBase
    {
        /// <summary>
        /// 表格标题
        /// </summary>
        [JsonProperty("headers")]
        public List<Header> HeaderList { get; set; }

        /// <summary>
        /// 表格内容
        /// </summary>
        [JsonProperty("rows")]
        public List<List<string>> RowList { get; set; }
    }
}