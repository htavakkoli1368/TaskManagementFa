using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagementFa.Data;
using TaskManagementFa.DTOs;
using TaskManagementFa.Model;

namespace TaskManagementFa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>>  GetAll()
        {
            var tasks = await _context.Tasks.ToListAsync();

            return Ok(tasks);
        }

        
    [HttpGet("{id}")]

    public async Task<ActionResult<TaskItem>> GetTaskById(int id)
    {
        var task = await _context.Tasks.FindAsync(id) ;
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]

    public async Task<ActionResult<TaskItem>> CreateTask(CreateTaskItemDto taskDto)
    {
        var task = new TaskItem
        {
            Title = taskDto.TaskName,
            Description = taskDto.Desc,
            IsCompleted = false
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTaskById), new { id = task.ID }, task);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult>  PutTask(int id, UpdataTaskItemDto task)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
        if (existingTask is null)
            return NotFound();
        existingTask.Title = task.TaskName;
        existingTask.Description = task.Desc;
        existingTask.IsCompleted = task.IsCompleted;
        await _context.SaveChangesAsync();
        return NoContent();
    }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null) 
                return NotFound();
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        //controller->DbContext->Ef core-> SQL Server

    }
}
