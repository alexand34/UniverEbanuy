using System;
using System.Collections.Generic;
using System.Text;

namespace ARoom.Dto.Dtos
{ 
    public class WarehouseZoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Color { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
