using System;
using System.Collections.Generic;

namespace ARoom.Common.Model
{
    public partial class Category : BaseEntity
    {
        public Category()
        {
            Goods = new HashSet<Good>();
        }

        public string Name { get; set; }
        public int ZoneId { get; set; }
        public string Shelving { get; set; }

        public virtual WarehouseZone Zone { get; set; }
        public virtual ICollection<Good> Goods { get; set; }
    }
}
