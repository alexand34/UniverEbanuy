using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;

namespace ARoom.Data.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(aRoomContext context) : base(context)
        {
        }
    }
}
