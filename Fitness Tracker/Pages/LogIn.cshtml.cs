using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fitness_Tracker.Model;
using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker.Pages
{
    public class LogInModel : PageModel
    {
        private readonly Fitness_Tracker.Model.TrackerContext _context;

        public LogInModel(Fitness_Tracker.Model.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            User.Id = 0;
            foreach (var user in _context.Users)
            {
                if (user.Name == User.Name || user.Password == User.Password)
                    User = user;
            }
            if (User.Id == 0)
            {
                return Page();
            }
            
            User.CurrentUser = true;
            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
