namespace Fitness_Tracker.Model;
using Fitness_Tracker.Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

public class Querie
{
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
}
