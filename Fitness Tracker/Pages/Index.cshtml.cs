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
    public class IndexModel : PageModel
    {
        private readonly Fitness_Tracker.Model.TrackerContext _context;
        public List<User> Users { get; set; } = new List<User>();
        public IndexModel(Fitness_Tracker.Model.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            foreach (var user in _context.Users)
            {
                user.CurrentUser = false;
            }
            _context.SaveChanges();
            return Page();

        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            User.CurrentUser = true;
            _context.Users.Add(User);


            return RedirectToPage("./CarList");
        }
    }
}
