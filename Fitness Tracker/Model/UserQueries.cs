namespace Fitness_Tracker.Model;
using Fitness_Tracker.Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

public class UserQueries
    {
        private readonly TrackerContext _context;

        public UserQueries(TrackerContext context)
        {
            _context = context;
        }

       //dobavqme chilleri
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //ID
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    
       
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

       //mahame geicheta
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

      // vsichki geicheta
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
}
