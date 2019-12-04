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

        public List<GoodDto> GetGoods(int categoryId, out int totalCount, string search = "", int pageSize = 25, int page = 1)
        {
            search = search.ToLower();
            var query = this._goodsRepository.Query().Where(x => (categoryId == -1 || x.CategoryId == categoryId) && (string.IsNullOrEmpty(search)
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
                Characteristics = good.Characteristics,
                ItemUniqueId = ""
            };

            this._goodsRepository.Add(dbGood);
            this._goodsRepository.SaveChanges();

            dbGood.ItemUniqueId = $"{dbGood.CategoryId}{dbGood.Name.Substring(0, 2)}{dbGood.Id}";
            this._goodsRepository.SaveChanges();
        }

        public void UpdateGood(GoodDto good)
        {
            var dbGood = _goodsRepository.GetByUniqueNumber(good.ItemUniqueId);

            dbGood.Name = good.Name;
            dbGood.Amount = good.Amount;
            dbGood.CategoryId = good.CategoryId;
            dbGood.Price = good.Price;
            dbGood.ShortCharacteristics = good.ShortCharacteristics;
            dbGood.Characteristics = good.Characteristics;

            this._goodsRepository.Update(dbGood);
            this._goodsRepository.SaveChanges(); ;
        }
    }
}
