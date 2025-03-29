using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fitness_Tracker.Model;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker.Pages
{
    public class CarListModel : PageModel
    {
        private readonly Fitness_Tracker.Model.TrackerContext _context;
        public List<User> Users { get; set; } = new List<User>();
        public List<Car> Cars { get; set; } = new List<Car>();
        public CarListModel(Fitness_Tracker.Model.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Cars = _context.Cars.ToList();
            Users = _context.Users.ToList();
            foreach(var user in Users)
            {
                if (user.CurrentUser)
                    User = user;
            }
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        public User User { get; set; } = new User();
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CarList");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int ID)
        {
            var Car = await _context.Cars.FindAsync(ID);

            if (Car != null)
            {
                _context.Cars.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}

