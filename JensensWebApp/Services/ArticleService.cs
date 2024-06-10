using JensensWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JensensWebApp.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IList<Article> _articles;

        public ArticleService()
        {
            _articles = new List<Article>
            {

            };
        }
        public IEnumerable<Article> GetArticles(int page, int pageSize)
        {
            return _articles.Skip((page - 1) * pageSize).Take(pageSize);
        }



    }

}
