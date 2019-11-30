using System;
using System.Collections.Generic;

namespace ARoom.Common.Model
{
    public partial class WarehouseZone : BaseEntity
    {
        public WarehouseZone()
        {
            Categories = new HashSet<Category>();
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
