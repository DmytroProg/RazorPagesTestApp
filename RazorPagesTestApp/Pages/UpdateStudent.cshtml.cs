using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Data;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages;

public class UpdateStudentModel : PageModel
{
    private readonly RazorPagesTestAppContext _context;

    public UpdateStudentModel(RazorPagesTestAppContext context)
    {
        _context = context;
    }

    [BindProperty] public Student Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var student = await _context.Student.FindAsync(id);
        if (student == null) return NotFound();
        Student = student;
        return Page();
        //return RedirectToPage("Index");
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(Student.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool StudentExists(int id)
    {
        return _context.Student.Any(e => e.Id == id);
    }
}