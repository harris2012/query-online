using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Vo
{
    public class ServerVo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("serverName")]
        public string ServerName { get; set; }

        [JsonProperty("serverType")]
        public string ServerType { get; set; }

        [JsonProperty("mysqlServerIp")]
        public string MysqlServerIp { get; set; }

        [JsonProperty("mysqlServerPort")]
        public string MysqlServerPort { get; set; }

        [JsonProperty("mysqlUsername")]
        public string MysqlUsername { get; set; }

        [JsonProperty("mysqlPassword")]
        public string MysqlPassword { get; set; }

        [JsonProperty("mysqlDBName")]
        public string MysqlDBName { get; set; }

        [JsonProperty("sqliteLocalPath")]
        public string SqliteLocalPath { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dataStatus")]
        public int DataStatus { get; set; }

        [JsonProperty("createTime")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("lastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }
    }
}