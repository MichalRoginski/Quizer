using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Project.NET.DataAccess;
using Project.NET.Models;

namespace Project.NET.Pages
{
    public class LoginModel : PageModel
    {   
        private readonly IConfiguration configuration;
        private readonly Ado_Net db;
        [BindProperty]
        public User user { get; set; }
        public LoginModel(IConfiguration configuration,Ado_Net dbAccessService)
        {
            this.configuration = configuration;
            db = dbAccessService;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            string password = db.GetPassword(user.username, configuration);

            if(password!=null)
            {
                user.password = user.GetHash(user.password);
                if (user.password==password)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.username)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                    await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");
                }
                return Page();
            }
            return Page();
        }
    }
}
