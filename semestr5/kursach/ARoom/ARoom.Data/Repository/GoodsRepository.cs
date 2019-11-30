using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;

namespace ARoom.Data.Repository
{
    public class GoodsRepository : BaseRepository<Good>, IGoodsRepository
    {
        private readonly aRoomContext context;
        public GoodsRepository(aRoomContext context) : base(context)
        {
            this.context = context;
        }

        public Good GetByUniqueNumber(string number)
        {
            return this.context.Goods.FirstOrDefault(x => x.ItemUniqueId == number);
        }
    }
}
