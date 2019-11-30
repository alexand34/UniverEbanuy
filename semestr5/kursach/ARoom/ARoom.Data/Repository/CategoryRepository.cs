using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;

namespace ARoom.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(aRoomContext context) : base(context)
        {
        }
    }
}
