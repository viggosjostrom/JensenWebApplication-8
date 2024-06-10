
using System.Collections.Generic;
using JensensWebApp.Models;

namespace JensensWebApp.Services
{
    public interface IArticleService
    {
        List<Article> GetArticles(int page, int pageSize);
    }
}
