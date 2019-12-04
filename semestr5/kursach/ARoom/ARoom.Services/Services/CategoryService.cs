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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public List<CategoryDto> GetCategories()
        {
            return this._categoryRepository.Query().Select(x => mapper.Map<CategoryDto>(x)).ToList();
        }

        public List<CategorySimpleDto> GetCategoriesSimple()
        {
            return this._categoryRepository.Query().Select(x => mapper.Map<CategorySimpleDto>(x)).ToList();
        }

        public void AddCategory(Category category)
        {
            this._categoryRepository.Add(category);
            this._categoryRepository.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            this._categoryRepository.Update(category);
            this._categoryRepository.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            this._categoryRepository.Remove(category);
            this._categoryRepository.SaveChanges();
        }
    }
}
