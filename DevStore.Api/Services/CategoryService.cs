using DevStore.Api.Data;
using DevStore.Api.DTOs;
using DevStore.Api.Models;

namespace DevStore.Api.Services
{
    public class CategoryService
    {
        private readonly AppDbContext context;

        public CategoryService(AppDbContext context)
        {
            this.context = context;
        }

        public CategoryResponseDto CreateCategory(CreateCategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Nome inválido");

            var category = new Category
            {
                Name = request.Name
            };

            context.Categories.Add(category);
            context.SaveChanges();

            return MapToResponseDto(category);
        }

        public List<CategoryResponseDto> GetAll()
        {
            var listDbCategories = context.Categories.ToList();

            List<CategoryResponseDto> listCategories = new();

            foreach (var category in listDbCategories)
                listCategories.Add(MapToResponseDto(category));

            return listCategories;
        }

        public CategoryResponseDto? GetById(int id)
        {
            var category = context.Categories.FirstOrDefault(a => a.Id == id);

            if (category == null)
                return null;

            return MapToResponseDto(category);

        }

        public CategoryResponseDto? UpdateCategory(int id, UpdateCategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Nome inválido");

            var category = context.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null)
                return null;

            category.Name = request.Name;

            context.SaveChanges();

            return MapToResponseDto(category);


        }

        public bool DeleteCategory(int id)
        {

            var category = context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
                return false;
           
            
            context.Categories.Remove(category);
            context.SaveChanges();
            

            return true;
        }

        private CategoryResponseDto MapToResponseDto(Category category)
        {
            var responseCategory = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return responseCategory;
        }
    }
}
