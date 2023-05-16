using System.ComponentModel.DataAnnotations;

namespace CRUD.ViewModels;

public class TaskViewModel
{
    [Required] public string? Title { get; set; }
    [Required] public string? Description { get; set; }
}