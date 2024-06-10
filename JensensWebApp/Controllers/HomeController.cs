using JensensWebApp.Models;
using JensensWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace JensensWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        public IActionResult Index(string topic = "", string sortBy = "")
        {
            const int initialPageSize = 12; // Number of articles to load initially

            // Get the first page of articles
            var articles = _articleService.GetArticles(1, initialPageSize).ToList();

            // Apply topic filter if needed
            if (!string.IsNullOrEmpty(topic))
            {
                articles = articles.Where(a => a.Topic.Contains(topic)).ToList();
            }

            // Apply sorting if needed
            switch (sortBy)
            {
                case "newest":
                    articles = articles.OrderByDescending(a => a.Published).ToList();
                    break;
                case "oldest":
                    articles = articles.OrderBy(a => a.Published).ToList();
                    break;
            }

            ViewBag.PageSize = initialPageSize; // Pass page size to the view

            return View(articles);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Subscription()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
