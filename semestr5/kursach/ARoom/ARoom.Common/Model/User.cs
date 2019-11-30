using System;
using System.Collections.Generic;

namespace ARoom.Common.Model
{
    public partial class User : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }

        public virtual Role Role { get; set; }
    }
}
