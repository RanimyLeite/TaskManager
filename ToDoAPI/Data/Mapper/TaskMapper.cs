using ToDoAPI.Data.Dtos;
using ToDoAPI.Models;

namespace ToDoAPI.Data.Mapper
{
    public class TaskMapper
    {
        public TaskModel TaskMapp(string id, TaskDto taskDto)
        {
            TaskModel task = new TaskModel()
            {
                Id = Guid.Parse(id),
                Title = taskDto.Title,
                Description = taskDto.Description,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            return task;
        }
    }
}
