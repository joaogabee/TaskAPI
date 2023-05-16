using CRUD.Database;
using CRUD.Models;
using CRUD.Repository;
using CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("v1")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetAllTasks([FromServices]AppDbContext context)
        {
            var taskResult = await TaskRepository.GetAllTasks(context);
            return Ok(taskResult);
        }
        [HttpPost]
        [Route("tasks")]
        public async Task<IActionResult> CreateTask([FromBody]TaskViewModel taskViewModel, [FromServices] AppDbContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var task = new TaskModel
            {
                Title = taskViewModel.Title,
                Description = taskViewModel.Description,
                StartDate = DateTime.Now,
                IsFinished = false
            };
            await TaskRepository.CreateTask(task, context);
            return Ok("Task Created");
        }
        [HttpGet]
        [Route("tasks/{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute]int id, [FromServices]AppDbContext context)
        {
            var taskResult = await TaskRepository.GetTaskById(id, context);
            if (taskResult != null)
            {
                return Ok(taskResult);
            }
            return BadRequest("ERROR 400 - Bad Request: Invalid ID");
        }

        [HttpPut]
        [Route("tasks/{id}")]
        public async Task<IActionResult> UpdateTaskById([FromRoute]int id, [FromBody]TaskViewModel taskViewModel, [FromServices]AppDbContext context)
        {
            TaskRepository.UpdateTaskById(id, taskViewModel, context);
            return Ok();
        }

        [HttpDelete]
        [Route("tasks/{id}")]
        public async Task<IActionResult> DeleteTaskById([FromRoute]int id, [FromServices] AppDbContext context)
        {
            TaskRepository.DeleteTask(id, context);
            return Ok();
        }
    }
}
