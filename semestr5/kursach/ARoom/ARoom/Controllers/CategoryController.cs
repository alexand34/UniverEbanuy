using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARoom.Common.Model;
using ARoom.Dto.Dtos;
using ARoom.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ARoom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCategories")]
        public List<CategoryDto> GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return categories;
        }

        [HttpGet]
        [Route("GetCategoriesSimple")]
        public List<CategorySimpleDto> GetCategoriesSimple()
        {
            var categories = _categoryService.GetCategoriesSimple();
            return categories;
        }

        [HttpPost]
        [Route("AddCategory")]
        public void AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public void DeleteCategory(Category category)
        {
            _categoryService.DeleteCategory(category);
        }
    }
}
