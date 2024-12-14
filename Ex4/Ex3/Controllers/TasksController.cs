using Ex3.Models;
using Ex3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITasksService _taskService;

        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _taskService.GetTaskById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("User/{userName}")]
        public IActionResult GetTasksByUserName(string userName)
        {
            var tasks = _taskService.GetTasksByUserName(userName);
            if (tasks == null || !tasks.Any())
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            task.TaskId = 0;
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(Get), new { Id = task.TaskId }, task);
        }

        //[HttpPost("UserTask")]
        //public IActionResult CreateUserTask(Tasks task, User user)
        //{
        //    task.User = user;
        //    _taskService.CreateUserTask(task, user);
        //    return CreatedAtAction(nameof(Get), new { Id = task.TaskId, User = user }, task);
        //}

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tasks task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }
            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }

    }
}
