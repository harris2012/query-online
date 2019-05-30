using MySql.Data.MySqlClient;
using Savory.DBSchema.Mysql;
using Savory.DBSchema.Sqlite;
using Savory.QueryOnline.Controllers.Request;
using Savory.QueryOnline.Controllers.Response;
using Savory.QueryOnline.Repository;
using Savory.QueryOnline.Repository.Entity;
using Savory.QueryOnline.Vo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Savory.QueryOnline.Controllers
{
    public class ServerController : ApiController
    {
        [HttpPost]
        [ActionName("items")]
        public ServerItemsResponse Items(ServerItemsRequest request)
        {
            ServerItemsResponse response = new ServerItemsResponse();

            ServerRepository repository = new ServerRepository();

            var entityList = repository.GetServerList();
            if (entityList != null && entityList.Count > 0)
            {
                List<ServerVo> returnValue = new List<ServerVo>();
                foreach (var entity in entityList)
                {
                    ServerVo vo = ToVo(entity);

                    returnValue.Add(vo);
                }
                response.ServerList = returnValue;
            }

            response.Status = 1;
            return response;
        }

        private static ServerVo ToVo(DesignServerEntity entity)
        {
            ServerVo server = new ServerVo();

            server.Id = entity.Id;
            server.ServerName = entity.ServerName;
            server.ServerType = entity.ServerType;

            server.MysqlServerIp = entity.MysqlServerIp;
            server.MysqlServerPort = entity.MysqlServerPort;
            server.MysqlUsername = entity.MysqlUsername;
            server.MysqlPassword = entity.MysqlPassword;
            server.MysqlDBName = entity.MysqlDBName;

            server.SqliteLocalPath = entity.SqliteLocalPath;

            server.Description = entity.Description;
            server.DataStatus = entity.DataStatus;
            server.CreateTime = entity.CreateTime;
            server.LastUpdateTime = entity.LastUpdateTime;

            return server;
        }
    }
}