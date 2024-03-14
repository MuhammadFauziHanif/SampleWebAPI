using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;

        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            return _articleBLL.GetArticleWithCategory();
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var article = _articleBLL.GetArticleById(id);
                return Ok(article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //get articles by category
        [HttpGet("GetArticleByCategory/{categoryId}")]
        public IActionResult GetArticleByCategory(int categoryId)
        {
            try
            {
                var articles = _articleBLL.GetArticleByCategory(categoryId);
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public IActionResult Post([FromBody] ArticleCreateDTO article)
        {
            try
            {
                _articleBLL.Insert(article);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ArticlesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ArticleUpdateDTO article)
        {
            try
            {
                _articleBLL.Update(article);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _articleBLL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
