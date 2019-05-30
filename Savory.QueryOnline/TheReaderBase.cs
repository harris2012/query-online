using MySql.Data.MySqlClient;
using Savory.QueryOnline.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline
{
    public class TheReaderBase
    {
        public static OpenDBResult GetConnection(DesignServerEntity serverEntity)
        {
            OpenDBResult openDBResult = new OpenDBResult();

            switch (serverEntity.ServerType)
            {
                case ServerTypeConstant.Mysql:
                    {
                        openDBResult = GetMysqlConnection(serverEntity);
                    }
                    break;
                case ServerTypeConstant.Sqlite:
                    {
                        openDBResult = GetSqliteConnection(serverEntity);
                    }
                    break;
                default:
                    {
                        openDBResult.Status = 404;
                        openDBResult.Message = "不支持的数据库";
                    }
                    break;
            }

            return openDBResult;
        }

        private static OpenDBResult GetMysqlConnection(DesignServerEntity serverEntity)
        {
            OpenDBResult openDBResult = new OpenDBResult();

            try
            {
                var connString = $"Server={serverEntity.MysqlServerIp};Port={serverEntity.MysqlServerPort};Database={serverEntity.MysqlDBName}; User={serverEntity.MysqlUsername};Password={serverEntity.MysqlPassword};Charset=utf8;Connection Timeout=3";

                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();

                openDBResult.Connection = connection;

                return openDBResult;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1042)
                {
                    openDBResult.Status = ex.Number;
                    openDBResult.Message = "数据库连接失败";
                }
                else
                {
                    openDBResult.Status = 500;
                    openDBResult.Message = ex.ToString();
                }
            }

            return openDBResult;
        }

        private static OpenDBResult GetSqliteConnection(DesignServerEntity serverEntity)
        {
            OpenDBResult openDBResult = new OpenDBResult();

            var connString = $"Data Source={serverEntity.SqliteLocalPath};Version=3;FailIfMissing=true;Read Only=true";

            SQLiteConnection connection = new SQLiteConnection(connString);
            connection.Open();

            openDBResult.Connection = connection;

            return openDBResult;
        }
    }
}