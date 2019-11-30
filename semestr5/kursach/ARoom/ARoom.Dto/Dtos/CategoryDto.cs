using System;
using System.Collections.Generic;
using System.Text;

namespace ARoom.Dto.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZoneId { get; set; }
        public string Shelving { get; set; }
    }
}
