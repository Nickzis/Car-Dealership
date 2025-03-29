using Fitness_Tracker.Model;


namespace Fitness_Tracker.UserAndCarRepo.UserRepo;

public class Repo
{
    private readonly TrackerContext _DbContext;

    public Repo (TrackerContext context)
    {
        _DbContext = context;
    }
    public List<User> GetUsers()
    {
        return _DbContext.Users.OrderBy(row => row.Name).ToList();
    }
    public void CreateUser (User user)
    {
        _DbContext.Users.Add(user);
        _DbContext.SaveChanges();
    }
    public void UpdateUser(User user)
    {
        _DbContext.Users.Update(user);
        _DbContext.SaveChanges();

    }

}
