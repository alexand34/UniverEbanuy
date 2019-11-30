using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Dto.Dtos;

namespace ARoom.Services.Contracts
{
    public interface IGoodService
    {
        List<GoodDto> GetGoods(out int totalCount, string search = "", int pageSize = 25, int page = 0);
        GoodDto GetGoodByUniqueNumber(string number);
        void AddGood(GoodDto good);
    }
}
