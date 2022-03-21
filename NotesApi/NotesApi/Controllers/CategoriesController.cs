using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        static List<Category> _categories = new List<Category>
        {
            new Category{Id = "1", Name = "To do"},
            new Category{Id = "2", Name = "Doing"},
            new Category{Id = "3", Name = "Done"}
        };

        /// <summary>
        /// Return list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categories);
        }

        /// <summary>
        /// Return category with a given id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetCategoryById(string Id)
        {
            var cat = _categories.FirstOrDefault(c => c.Id == Id);
            return Ok(cat);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category cat)
        {
            _categories.Add(cat);
            return Ok(_categories);
        }

        /// <summary>
        /// Delete a category with a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(string id)
        {
            var cat = _categories.FirstOrDefault(c => c.Id == id);
            _categories.Remove(cat);
            return Ok(_categories);
        }
    }
}
