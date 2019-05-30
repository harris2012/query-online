using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Repository
{
    public abstract class RepositoryBase
    {
        protected IDbConnection GetConnection()
        {
            var connString = ConfigurationManager.ConnectionStrings["WebSql"].ConnectionString;

            SQLiteConnection connection = new SQLiteConnection(connString);
            connection.Open();

            return connection;
        }
    }
}