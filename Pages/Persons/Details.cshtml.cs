using azure_app_kembos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace azure_app_kembos.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly azure_app_kembos.Data.AppDbContext _context;

        public DetailsModel(azure_app_kembos.Data.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
