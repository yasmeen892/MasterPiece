
using LMS10_1.Data;
using Microsoft.AspNetCore.Mvc;

namespace LMS10_1.Models.ViewComponents
{
    public class ArticleViewComponent : ViewComponent
    {
        private ApplicationDbContext db;
        public ArticleViewComponent(ApplicationDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            return View(db.Articles.ToList());
        }

    }
}
