using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARoom.Dto.Dtos;

namespace ARoom.ViewModel
{
    public class GoodsViewModel
    {
        public List<GoodDto> Goods { get; set; }
        public int TotalCount { get; set; }
    }
}
