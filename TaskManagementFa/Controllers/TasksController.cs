using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementFa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // Get /api/tasks
        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = new List<string>
            {
                "Task 1",
                "Task 2",
                "Task 3"
            };
            return Ok(tasks);
        }
        //Get /api/tasks/active
        [HttpGet("active")]
        public IActionResult Get()
        {
            var tasks = new List<string>
            {
                "Task 1",
                "Task 2",
                "Task 3"
            };
            return Ok(tasks);
        }
        // Get /api/tasks/{id}
        [HttpGet("{id}")]
        public IActionResult GetTasksById(int id)
        {
            return Ok(id);
        }

        //post /api/tasks
        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
