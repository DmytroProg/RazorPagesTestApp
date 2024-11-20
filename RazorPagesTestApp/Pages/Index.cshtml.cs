using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Johnson",
                LastLoggedIn = DateTime.Now,
                PresenceType = PresenceStatus.Present,
                IsOnline = true,
                Grade = 12,
                DiamondsCount = 3,
                Comment = null
            }
        };
    }

    public IEnumerable<Student> Students { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPostAddTitle()
    {
        return Page();
    }
}