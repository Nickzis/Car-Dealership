using Microsoft.Data.SqlClient;
using System.Configuration;
using Fitness_Tracker.Model;
namespace Fitness_Tracker.Model
{
    public class CarQueries
    {
        private readonly TrackerContext _context;
        public CarQueries(TrackerContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.ID == id);
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }
    }
}