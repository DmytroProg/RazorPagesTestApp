using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Data;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages;

public class IndexModel : PageModel
{
    private readonly RazorPagesTestAppContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, RazorPagesTestAppContext context)
    {
        _logger = logger;
        _context = context;
        Students = new List<Student>();
    }

    [BindProperty] public List<Student> Students { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Session.GetString("nickname") == null)
        {
            return RedirectToPage("Login");
        }
        
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

    public async Task<IActionResult> OnGetDeleteStudentAsync(int id)
    {
        var student = await _context.Student.FindAsync(id);

        if (student == null) return NotFound();
        
        _context.Student.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}