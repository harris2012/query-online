using Dapper;
using Savory.QueryOnline.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Repository
{
    public class ServerRepository: RepositoryBase
    {
        public List<DesignServerEntity> GetServerList()
        {
            var sql = "select * from designserver";

            using (var conn = GetConnection())
            {
                return conn.Query<DesignServerEntity>(sql).ToList();
            }
        }

        public DesignServerEntity GetServer(string serverName)
        {
            var sql = "select * from designserver where ServerName = @ServerName";

            using (var conn = GetConnection())
            {
                return conn.QueryFirstOrDefault<DesignServerEntity>(sql, new { ServerName = serverName });
            }
        }
    }
}