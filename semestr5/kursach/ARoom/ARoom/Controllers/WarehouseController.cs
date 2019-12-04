using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using ARoom.Common.Model;
using ARoom.Dto.Dtos;
using ARoom.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ARoom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseZonesService zonesService;
        public WarehouseController(IWarehouseZonesService zonesService)
        {
            this.zonesService = zonesService;
        }

        [HttpGet]
        [Route("getZones")]
        public List<WarehouseZoneDto> GetZones()
        {
            return zonesService.GetZones();
        }

        [HttpGet]
        [Route("getZonesSimple")]
        public List<WarehouseZoneDto> GetZonesSimple()
        {
            return zonesService.GetZones();
        }

        [HttpPost]
        [Route("add")]
        public void AddZone(WarehouseZone zone)
        { 
            zonesService.AddZone(zone);
        }
    }
}
