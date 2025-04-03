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
        public List<User> Users { get; set; } = new List<User>();
        public EditModel(Fitness_Tracker.Model.TrackerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Car Car { get; set; } = new Car();
        public Car CurrentCar { get; set; } = new Car();

        public User User { get; set; } = new User();
        public IActionResult OnPostId(int? id)
        {
            Users = _context.Users.ToList();
            foreach (var user in Users)
            {
                if (user.CurrentUser)
                    User = user;
            }
            if (User == null)
            {
                return NotFound();
            }

            if (id == null)
            {
                return NotFound();
            }

            CurrentCar = _context.Cars.FirstOrDefault(m => m.ID == id);
            if (CurrentCar == null)
            {
                return NotFound();
            }
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
