using Ex3.Models;
using Ex3.Repositories;

namespace Ex3.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _taskRepository;

        public TasksService(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Tasks> GetTasks()
        {
            var allTasks = _taskRepository.GetAll();
            return allTasks;
        }

        public void AddTask(Tasks newTask)
        {
            _taskRepository.Add(newTask);
        }

        public Tasks GetTaskById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public List<Tasks> GetTasksByUserName(string userName)
        {
            return _taskRepository.GetTasksByUserName(userName); 
        }

        public void CreateUserTask(Tasks task, User user)
        {
             _taskRepository.CreateUserTask(task, user);
        }


        public void UpdateTask(Tasks task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }
    }
}
