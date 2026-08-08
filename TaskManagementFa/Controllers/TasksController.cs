using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementFa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

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
    }
}
