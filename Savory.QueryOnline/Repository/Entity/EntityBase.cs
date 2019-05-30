using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savory.QueryOnline.Repository.Entity
{
    public class EntityBase
    {
        public int Id { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}