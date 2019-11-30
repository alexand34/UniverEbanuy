using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;

namespace ARoom.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(aRoomContext context) : base(context)
        {
        }
    }
}
