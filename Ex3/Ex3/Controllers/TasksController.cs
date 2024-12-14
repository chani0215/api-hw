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

        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(Get), new { Id = task.id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tasks task)
        {
            if (id != task.id)
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
