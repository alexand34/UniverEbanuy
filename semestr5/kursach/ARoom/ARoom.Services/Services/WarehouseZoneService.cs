using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;
using ARoom.Dto.Dtos;
using ARoom.Services.Contracts;
using AutoMapper;

namespace ARoom.Services.Services
{
    public class WarehouseZoneService : IWarehouseZonesService
    {
        private readonly IWarehouseZoneRepository _warehouseRepository;
        private readonly IMapper _mapper;
        public WarehouseZoneService(IWarehouseZoneRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public List<WarehouseZoneDto> GetZones()
        {
            var data = this._warehouseRepository.Query().ToList();
            var returnData = data.Select(x => _mapper.Map<WarehouseZoneDto>(x)).ToList();

            foreach (var zone in data)
            {
                var ret = returnData.FirstOrDefault(x => x.Id == zone.Id);
                ret.Categories = zone.Categories.Select(x => _mapper.Map<CategoryDto>(x)).ToList();
            }

            return returnData;
        }

        public void AddZone(WarehouseZone zone)
        {
            this._warehouseRepository.Add(zone);
            this._warehouseRepository.SaveChanges();
        }

        public void DeleteZone(int zoneId)
        {
            var zone = this._warehouseRepository.GetById(zoneId);
            this._warehouseRepository.Remove(zone);
            this._warehouseRepository.SaveChanges();
        }

        public void UpdateZone(WarehouseZone zone)
        {
            this._warehouseRepository.Update(zone);
            this._warehouseRepository.SaveChanges();
        }
    }
}
