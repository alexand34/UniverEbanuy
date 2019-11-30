using System;
using System.Collections.Generic;
using System.Text;

namespace ARoom.Dto.Dtos
{
    public class GoodDto
    {
        public string ItemUniqueId { get; set; }
        public string Name { get; set; }
        public string ShortCharacteristics { get; set; }
        public string Characteristics { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int Amount { get; set; }
    }
}