using azure_app_kembos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace azure_app_kembos.Pages.Persons
{
    public class DeleteModel : PageModel
    {
            private readonly azure_app_kembos.Data.AppDbContext _context;

            public DeleteModel(azure_app_kembos.Data.AppDbContext context)
            {
                _context = context;
            }

            [BindProperty]
            public Person Person { get; set; } = default!;

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null || _context.Persons == null)
                {
                    return NotFound();
                }

                var person = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    Person = person;
                }
                return Page();
            }

            public async Task<IActionResult> OnPostAsync(int? id)
            {
                if (id == null || _context.Persons == null)
                {
                    return NotFound();
                }
                var person = await _context.Persons.FindAsync(id);

                if (person != null)
                {
                    Person = person;
                    _context.Persons.Remove(Person);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./Index");
            }
        }
}
