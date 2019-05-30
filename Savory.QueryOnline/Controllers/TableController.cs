using MySql.Data.MySqlClient;
using Savory.DBSchema.Mysql;
using Savory.DBSchema.Sqlite;
using Savory.QueryOnline.Controllers.Request;
using Savory.QueryOnline.Controllers.Response;
using Savory.QueryOnline.Repository;
using Savory.QueryOnline.Vo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Savory.QueryOnline.Controllers
{
    public class TableController : ApiController
    {
        [HttpPost]
        public TableItemsResponse Items(TableItemsRequest request)
        {
            TableItemsResponse response = new TableItemsResponse();

            ServerRepository serverRepository = new ServerRepository();
            var serverEntity = serverRepository.GetServer(request.ServerName);
            if (serverEntity == null)
            {
                response.Message = "服务器不存在";
                return response;
            }

            OpenDBResult openDBResult = TheReaderBase.GetConnection(serverEntity);
            if (openDBResult.Status != 0)
            {
                response.Status = openDBResult.Status;
                response.Message = openDBResult.Message;
                return response;
            }

            using (var conn = openDBResult.Connection)
            {
                switch (serverEntity.ServerType)
                {
                    case ServerTypeConstant.Mysql:
                        {

                            var entityList = MysqlReader.GetTableEntityList(conn as MySqlConnection, serverEntity.MysqlDBName);

                            response.TableList = entityList.Select(v => new SchemaTableVo { Name = v.Name }).ToList();

                        }
                        break;
                    case ServerTypeConstant.Sqlite:
                        {
                            var entityList = SqliteReader.GetTableEntityList(conn as SQLiteConnection);

                            response.TableList = entityList.Select(v => new SchemaTableVo { Name = v.Name }).ToList();
                        }
                        break;
                    default:
                        {
                            response.Message = "不支持的数据库类型";

                            return response;
                        }
                }
            }

            response.Status = 1;
            return response;
        }
    }
}