using BlogWebsite.Data;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;

namespace BlogWebsite.Controllers
{
	
	public class AccountController : Controller
    {
        int UID;

        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _db;

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }


		[Authorize]

		public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Login()
        {
            return View();
        }



		
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


			

			return RedirectToAction("Login", "Account");


        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ContainerViewModel signup)
        {
            if(ModelState.IsValid)
            {
                var userDetails = new UserDetails();
                userDetails.Name = signup.FirstName + " " + signup.LastName;
                userDetails.ContactNumber = signup.Contact_Number;
                userDetails.Gender= signup.Gender;

                var userLogins = new UserLogin();
                userLogins.UserName = signup.UserName;
                userLogins.Email = signup.Email;
                userLogins.Password= signup.Password;

                userLogins.UserDetails = userDetails;
                _db.Logins.Add(userLogins);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(signup);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {

                var users = _db.Logins.Where(y => y.UserName == login.EmailorUsername || y.Email == login.EmailorUsername && y.Password == login.Password).SingleOrDefault();

               

                if (users == null)
                {
                    ViewBag.error="Invalid user Name or password";
                    return View(login);
                }

                else
                {
                    UID = users.Id;
                    Console.WriteLine("WElcome Blogger");

					var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, users.Email),
			new Claim("FullName", users.UserName),
           new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()),
			new Claim(ClaimTypes.Role, "Administrator"),
		};
                    
					var claimsIdentity = new ClaimsIdentity(
						claims, CookieAuthenticationDefaults.AuthenticationScheme);

					var authProperties = new AuthenticationProperties
					{
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = false,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
					};

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    // Set current principal
                    Thread.CurrentPrincipal = claimsPrincipal;

                    HttpContext.SignInAsync(
						CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(claimsIdentity),
						authProperties);



					return RedirectToAction("HomePage", "Pages", new { uid = UID });
                }

            }
        
        return RedirectToAction(nameof(Index));

        }

		[Authorize]
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


		[Authorize]
		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}