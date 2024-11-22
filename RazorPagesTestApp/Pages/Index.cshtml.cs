using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Data;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly RazorPagesTestAppContext _context;

    public IndexModel(ILogger<IndexModel> logger, RazorPagesTestAppContext context)
    {
        _logger = logger;
        _context = context;
        Students = new List<Student>();
    }

    [BindProperty] 
    public List<Student> Students { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        Students = await _context.Student.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        foreach (var student in Students)
        {
            var studentFromDb = await _context.Student.FindAsync(student.Id);
            studentFromDb.PresenceType = student.PresenceType;
            studentFromDb.IsOnline = student.IsOnline;
            studentFromDb.Grade = student.Grade;
            studentFromDb.DiamondsCount = student.DiamondsCount;
        }
        
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }

    public IActionResult OnGetAddStudent()
    {
        return RedirectToPage("AddStudent");
    }
}