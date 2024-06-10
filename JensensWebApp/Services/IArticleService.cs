using JensensWebApp.Models;
using System.Collections.Generic;

namespace JensensWebApp.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles(int page, int pageSize);
    }
}
