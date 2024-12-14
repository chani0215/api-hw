using Ex3.Models;

namespace Ex3.Services
{
    public interface ITasksService
    {
        List<Tasks> GetTasks();
        Tasks GetTaskById(int id);
        void AddTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTask(int id);
        List<Tasks> GetTasksByUserName(string userName); 

        void CreateUserTask(Tasks task, User user);
    }

}
