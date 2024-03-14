using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;

        public CategoriesController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return _categoryBLL.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _categoryBLL.GetById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryCreateDTO category)
        {
            try
            {
                _categoryBLL.Insert(category);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CategoryUpdateDTO category)
        {
            try
            {
                _categoryBLL.Update(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryBLL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
