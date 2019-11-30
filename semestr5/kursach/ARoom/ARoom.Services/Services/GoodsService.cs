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
    public class GoodsService : IGoodService
    {
        private readonly IGoodsRepository _goodsRepository;
        private readonly IMapper _mapper;
        public GoodsService(IGoodsRepository goodsRepository, IMapper mapper)
        {
            this._goodsRepository = goodsRepository;
            this._mapper = mapper;
        }

        public List<GoodDto> GetGoods(out int totalCount, string search = "", int pageSize = 25, int page = 1)
        {
            search = search.ToLower();
            var query = this._goodsRepository.Query().Where(x => (string.IsNullOrEmpty(search)
                                                                  || x.Name.ToLower().Contains(search)
                                                                  || x.ItemUniqueId.Contains(search)))
                .Select(x => _mapper.Map<GoodDto>(x));

            totalCount = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public GoodDto GetGoodByUniqueNumber(string number)
        {
            return _mapper.Map<GoodDto>(_goodsRepository.GetByUniqueNumber(number));
        }

        public void AddGood(GoodDto good)
        {
            var dbGood = new Good()
            {
                Name = good.Name,
                Amount = good.Amount,
                CategoryId = good.CategoryId,
                Price = good.Price,
                ShortCharacteristics = good.ShortCharacteristics,
                Characteristics = good.Characteristics
            };

            this._goodsRepository.Add(dbGood);
            dbGood.ItemUniqueId = $"{dbGood.Category.Name.Substring(0, 2)}{dbGood.CategoryId}{dbGood.Name.Substring(0, 2)}{dbGood.Id}";
            this._goodsRepository.SaveChanges();;
        }
    }
}
