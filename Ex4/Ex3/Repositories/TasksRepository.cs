using Ex3.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex3.Repositories
{
    public class TasksRepository : ITasksRepository
    {

        private readonly TasksContext _context;

        public TasksRepository(TasksContext context)
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
            if (task != null)
                return task;
            return new Tasks();
        }

        public void Update(Tasks task)
        {
            _context.tasks.Update(task);
            _context.SaveChanges();
        }
        public List<Tasks>? GetTasksByUserName(string userName)
        {
            User? currUser = _context.users.FirstOrDefault(u => u.UserName == userName);
            if (currUser != null)
            {
                List<Tasks>? tasksOfUser = _context.tasks.Where(t => t.UserId == currUser.UserId).ToList();
                return tasksOfUser;
            }
            return null;
        }

        public void CreateUserTask(Tasks task, User user)
        {
             _context.tasks.Add(task);
        }
    }
}
