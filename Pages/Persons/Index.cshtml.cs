using azure_app_kembos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace azure_app_kembos.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly azure_app_kembos.Data.AppDbContext _context;

        public IndexModel(azure_app_kembos.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Persons != null)
            {
                Person = await _context.Persons.ToListAsync();
            }
        }
    }
}
