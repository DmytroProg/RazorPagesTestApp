using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestApp.Data;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages;

public class AddStudentModel : PageModel
{
    private readonly RazorPagesTestAppContext _context;

    public AddStudentModel(RazorPagesTestAppContext context)
    {
        _context = context;
    }

    [BindProperty] public Student Student { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Student.Add(Student);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}