using Microsoft.AspNetCore.Mvc;
using JensensWebApp.Models;
using JensensWebApp.Services;
using System.Collections.Generic;

namespace JensensWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetArticles(int page = 1, int pageSize = 12)
        {
            var articlesForPage = _articleService.GetArticles(page, pageSize);
            return Ok(articlesForPage);
        }
    }
}
