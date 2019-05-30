using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Repository.Entity
{
    public class DesignServerEntity : EntityBase
    {
        public string ServerName { get; set; }

        public string ServerType { get; set; }

        public string MysqlServerIp { get; set; }

        public string MysqlServerPort { get; set; }

        public string MysqlUsername { get; set; }

        public string MysqlPassword { get; set; }

        public string MysqlDBName { get; set; }

        public string SqliteLocalPath { get; set; }

        public string Description { get; set; }
    }
}