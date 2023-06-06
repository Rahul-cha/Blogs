using BlogWebsite.Data;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
	[Authorize]
	public class BlogsController : Controller
    {
		

		private readonly ApplicationDbContext _db;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public BlogsController(ApplicationDbContext dbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _db = dbcontext;
			_webHostEnvironment = webHostEnvironment;
		}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PostBlog(int uid)
        {
            ViewBag.Uid = uid;
            //Yeta uid Kasari lyaune
            //Name?? ViewBag?
            return View();
        }

        [HttpPost]
        public IActionResult PostBlog(BlogPost post)
        {

            if (ModelState.IsValid)
            {
                if (post.Image != null)
                {
                    string folder = "blogs/images";
                    folder += Guid.NewGuid().ToString() + "_" + post.Image.FileName;
                    post.ImageUrl = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    post.Image.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }


                _db.Add(post);
                _db.SaveChanges();

            }

            return RedirectToAction("HomePage", "Pages");
        }
    }
}
