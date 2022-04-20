using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNoteWebApp.Server.Services.Category;
using ElevenNoteWebApp.Shared.Models.Category;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElevenNoteWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }


        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Category(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null) return NotFound();

            return Ok(category);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _categoryService.CreateCategoryAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
