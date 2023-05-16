using CRUD.Database;
using CRUD.Models;
using CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository;

public static class TaskRepository
{
    public static Task<List<TaskModel>> GetAllTasks([FromServices] AppDbContext context)
    {
        var tasks = context.TaskDB.AsNoTracking().ToListAsync();
        return tasks;
    }

    public static async Task CreateTask(TaskModel task, [FromServices] AppDbContext context)
    {
        await context.TaskDB.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public static Task<TaskModel?> GetTaskById(int id, [FromServices] AppDbContext context)
    {
        var taskResult =  context.TaskDB.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return taskResult;
    }

    public static async void UpdateTaskById(int id, [FromBody]TaskViewModel taskViewModel, [FromServices] AppDbContext context)
    {
        var taskResult = await context.TaskDB.FirstOrDefaultAsync(x => x.Id == id);
        if (taskResult != null)
        {
            taskResult.Title = taskViewModel.Title;
            taskResult.Description = taskViewModel.Description;
            context.TaskDB.Update(taskResult);
            await context.SaveChangesAsync();
        }
    }

    public static async void DeleteTask(int id, [FromServices] AppDbContext context)
    {
        var taskResult = await context.TaskDB.FirstOrDefaultAsync(x => x.Id == id);
        if (taskResult != null)
        {
            context.TaskDB.Remove(taskResult); 
            await context.SaveChangesAsync();
        }
    }
}