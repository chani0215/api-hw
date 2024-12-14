using Ex3.Models;
namespace Ex3.Repositories
{
    public interface ITasksRepository
    {
        List<Tasks> GetAll();
        Tasks GetById(int id);
        void Add(Tasks task);
        void Update(Tasks task);
        void Delete(int id);
        List<Tasks> GetTasksByUserName(string userName);

        void CreateUserTask(Tasks task, User user);

    }
}
