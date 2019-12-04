using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;
using ARoom.Dto.Dtos;

namespace ARoom.Services.Contracts
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        List<CategorySimpleDto> GetCategoriesSimple();
    }
}
