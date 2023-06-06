using BlogWebsite.Data;
using BlogWebsite.Models;
using BlogWebsite.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Security.Principal;

namespace BlogWebsite.Controllers
{
	[Authorize]
	public class PagesController : Controller
    {
		
        private readonly ApplicationDbContext _db;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public PagesController(ApplicationDbContext dbcontext, IWebHostEnvironment webHostEnvironment)
		{
			_db = dbcontext;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
        {
            return View();
        }



		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult HomePage(int uid)
        {
            var userDetails = _db.Blogs.ToList();
            ViewBag.Uid = uid;

            //var userDetails = _db.Details.Where(y=>y.LoginId== uid).SingleOrDefault();

            ViewBag.Name = _db.Details.Where(y=> y.LoginId == uid).Select(y=>y.Name).SingleOrDefault();

           var blogPostVmList = new List<BlogPostViewModel>();

            foreach (var item in userDetails)
            {
                var blogPost = new BlogPostViewModel();

				blogPost.Name = _db.Logins.Where(t => t.Id == item.UserLoginId).Select(t => t.UserName).SingleOrDefault();


				blogPost.PostTitle = item.Title;
				blogPost.PostDescription = item.Description;
				blogPost.CreatedDate = item.CreatedDate;
				blogPost.ImageUrl = item.ImageUrl;
                //blogPost.BlogImage = item.Image;
                blogPostVmList.Add(blogPost);
			}
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.UserId = userId;


            return View(blogPostVmList);

        }

        public IActionResult PersonalBlogs(int uid, string name)
        {
            var Pblogs = _db.Blogs.Where(y=>y.UserLoginId == uid).ToList();
            //ViewBag.Name = _db.Details.Where(y => y.LoginId == uid).Select(y => y.Name).SingleOrDefault();

            ViewBag.Name = name;
			return View(Pblogs);
        }

        public IActionResult ProfilePage(int uid)
        {
            var Details = _db.Details.Where(y=>y.LoginId== uid).SingleOrDefault();
            
            //foreach(var items in Details)
            //{
            //    ViewBag.profilepic = items.ProfilePic;
            //    ViewBag.name = items.Name;
            //    ViewBag.contactno = items.ContactNumber;
            //    ViewBag.bio = items.ProfileBio;
                
            //}

            var dDetails = _db.Logins.Where(y=>y.Id== uid).SingleOrDefault();
           

            ViewProfileViewModel viewprofiln = new ViewProfileViewModel();
            viewprofiln.uid  = uid;
            viewprofiln.UserName = dDetails.UserName;
            viewprofiln.Gender = Details.Gender;
            viewprofiln.Contact_Number = Details.ContactNumber;
            viewprofiln.Name = Details.Name;

                   //return View(viewprofiln);

            return View(viewprofiln);
        }

        [HttpPost]
        public IActionResult ProfilePage(ViewProfileViewModel update)
        {
            if (ModelState.IsValid)
            {
                var details = new UserDetails();
                details.Name = update.Name;
                details.ContactNumber = update.Contact_Number;
                //Profile Picture
                //Bio
                details.ProfileBio = update.Bio;
                details.ProfilePic= update.ProfilePic;

                //var loginDetails = new UserLogin();
                //loginDetails.Email = update.Email;
                //loginDetails.UserName = update.UserName;

                if (update.ProfilePic != null)
                {
					string folder = "blogs/images";
					folder += Guid.NewGuid().ToString() + "_" + update.ProfilePic.FileName;
					update.ProfileImgUrl = "/" + folder;

					string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

					update.ProfilePic.CopyTo(new FileStream(serverFolder, FileMode.Create));
				}



				//loginDetails.UserDetails = details ;
				_db.Details.Update(details);
				_db.SaveChanges();

				return RedirectToAction("ProfilePage", "Pages");




			}
            return View();
        }
      
        //[HttpPost]
        //public IActionResult HomePage(BlogPost Post)
        //{
        //    //if (ModelState.IsValid)
        //    //{ }
        //        _db.Blogs.Add(Post);
        //        _db.SaveChanges();
            

        //    return RedirectToAction("HomePage");
        //}


    }
}
