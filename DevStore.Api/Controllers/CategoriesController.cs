using DevStore.Api.DTOs;
using DevStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = categoryService.GetById(id);

            if (category == null)
                return NotFound();


            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequest request)
        {
            try
            {
                var category = categoryService.CreateCategory(request);
                return Created("", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryRequest request)
        {
            try
            {
                var categoryUpdate = categoryService.UpdateCategory(id, request);

                if (categoryUpdate == null)
                    return NotFound();

                return Ok(categoryUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var categoryDelete = categoryService.DeleteCategory(id);
                if (categoryDelete == true)
                    return NoContent();

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
