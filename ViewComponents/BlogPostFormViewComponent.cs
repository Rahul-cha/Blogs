using BlogWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.ViewComponents
{
    public class BlogPostFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int uid)
        {
            var blogs = new BlogPost();

            blogs.UserLoginId = uid;
            return View(blogs);

           
        }
    }
}
