using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fitness_Tracker.Model;  
using System;
using System.Linq;

namespace Fitness_Tracker.Pages
{
    public class QuerieListModel : PageModel
    {
        private readonly TrackerContext _context;

        public QuerieListModel(TrackerContext context)
        {
            _context = context;
        }

        public IQueryable<Querie> Querries { get; set; }

        public void OnGet()
        {
            var carId = Request.Query["CarId"].ToString();
            var userId = Request.Query["UserId"].ToString();
            var startDate = Request.Query["StartDate"].ToString();
            var endDate = Request.Query["EndDate"].ToString();

            IQueryable<Querie> query = _context.Querries;

            if (!string.IsNullOrEmpty(carId) && int.TryParse(carId, out var carIdValue))
            {
                query = query.Where(q => q.CarId == carIdValue);
            }

            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out var userIdValue))
            {
                query = query.Where(q => q.UserId == userIdValue);
            }

            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out var startDateValue))
            {
                query = query.Where(q => q.StartDate >= startDateValue);
            }

            if (!string.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out var endDateValue))
            {
                query = query.Where(q => q.EndDate <= endDateValue);
            }

            
            Querries = query;
        }
    }
}
