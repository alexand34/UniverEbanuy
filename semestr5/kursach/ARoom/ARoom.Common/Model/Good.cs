using System;
using System.Collections.Generic;

namespace ARoom.Common.Model
{
    public partial class Good : BaseEntity
    {
        public string ItemUniqueId { get; set; }
        public string Name { get; set; }
        public string ShortCharacteristics { get; set; }
        public string Characteristics { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int Amount { get; set; }

        public virtual Category Category { get; set; }
    }
}
