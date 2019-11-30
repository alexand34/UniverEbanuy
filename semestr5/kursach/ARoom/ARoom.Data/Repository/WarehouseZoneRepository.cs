using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ARoom.Data.Repository
{
    public class WarehouseZoneRepository : BaseRepository<WarehouseZone>, IWarehouseZoneRepository
    {
        private readonly aRoomContext context;
        public WarehouseZoneRepository(aRoomContext context) : base(context)
        {
            this.context = context;
        }

        //public override IEnumerable<WarehouseZone> Query()
        //{
        //    return this.context.WarehouseZones;
        //}
    }
}
