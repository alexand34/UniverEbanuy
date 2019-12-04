using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Dto.Dtos;

namespace ARoom.Services.Contracts
{
    public interface IWarehouseZonesService
    {
        List<WarehouseZoneDto> GetZones();
        List<WarehouseZoneSimpleDto> GetZonesSimple();
        void AddZone(WarehouseZone zone);
        void DeleteZone(int zoneId);
        void UpdateZone(WarehouseZone zone);
    }
}
