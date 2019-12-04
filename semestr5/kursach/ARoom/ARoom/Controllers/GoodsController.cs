using ARoom.Dto.Dtos;
using ARoom.Services.Contracts;
using ARoom.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ARoom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {
        private readonly IGoodService _goodService;
        public GoodsController(IGoodService goodService)
        {
            this._goodService = goodService;
        }

        [HttpPost]
        [Route("add")]
        public void AddGood(GoodDto good)
        {
            this._goodService.AddGood(good);
        }


        [HttpPost]
        [Route("update")]
        public void UpdateGood(GoodDto good)
        {
           this._goodService.UpdateGood(good);
        }



        [HttpGet]
        [Route("GetGoods")]
        public GoodsViewModel GetGoods(int category = -1, string search = "", int pageSize = 25, int page = 1)
        {
            var viewModel = new GoodsViewModel();

            viewModel.Goods = this._goodService.GetGoods(category, out var totalCount, search, pageSize, page);
            viewModel.TotalCount = totalCount;

            return viewModel;
        }
    }
}
