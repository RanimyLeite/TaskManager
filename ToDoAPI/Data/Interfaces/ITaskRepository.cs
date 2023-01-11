using FluentResults;
using ToDoAPI.Models;

namespace ToDoAPI.Data.Interfaces
{
    public interface ITaskRepository
    {
        List<TaskModel> GetTasks();
        TaskModel GetTaskById(string id);
        void CreateTask(TaskModel taskModel);
        Result UpdateTask(TaskModel task);
        Result DeleteTask(string id);
    }
}
