using Ex3.Models;

namespace Ex3.Repositories
{
    public class TasksRepository : ITasksRepository
    {

        private readonly TasksDbContext _context;

        public TasksRepository(TasksDbContext context)
        {
            _context = context;
        }

        public void Add(Tasks task)
        {
            _context.tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tasks? task = _context.tasks.Find(id);

            if (task != null)
            {
                _context.tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<Tasks> GetAll()
        {
            return _context.tasks.ToList();
        }

        public Tasks GetById(int id)
        {
            Tasks? task = _context.tasks.Find(id);
            return task;
        }

        public void Update(Tasks task)
        {
            _context.tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
