using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline
{
    public class OpenDBResult
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public IDbConnection Connection { get; set; }
    }
}