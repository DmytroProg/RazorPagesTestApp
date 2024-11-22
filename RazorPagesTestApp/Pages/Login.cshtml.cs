using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages;

public class Login : PageModel
{
    
    [BindProperty] public User User { get; set; }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (User.Nickname == "teacher" && User.Password == "123")
        {
            // save in session
            HttpContext.Session.SetString("nickname", User.Nickname);
            
            return RedirectToPage("Index");
        }

        return Page();
    }
}