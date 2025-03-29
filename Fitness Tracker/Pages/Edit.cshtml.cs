using Fitness_Tracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fitness_Tracker.Model;
using Microsoft.EntityFrameworkCore;
namespace Fitness_Tracker.Pages
{
    public class EditModel : PageModel
    {
        private readonly Fitness_Tracker.Model.TrackerContext _context;
        public List<Car> Cars { get; set; } = new List<Car>();
        public EditModel(Fitness_Tracker.Model.TrackerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Car = await _context.Cars.FirstOrDefaultAsync(m => m.ID == id);
            if (Car == null)
            {
                return NotFound();
            }
            Car = Car;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CarList");
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.ID == id);
        }
    }
}
