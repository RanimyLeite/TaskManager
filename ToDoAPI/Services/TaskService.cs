using FluentResults;
using ToDoAPI.Data.Dtos;
using ToDoAPI.Data.Mapper;
using ToDoAPI.Models;
using ToDoAPI.Repositories;

namespace ToDoAPI.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        private readonly TaskMapper _mapper;

        public TaskService(TaskRepository repository, TaskMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<TaskModel> GetTasks()
        {
            var result = _repository.GetTasks();

            return result;
        }

        public TaskModel GetTaskById(string id)
        {
            var result = _repository.GetTaskById(id);

            return result;
        }

        public void CreateTask(TaskModel model)
        {
            _repository.CreateTask(model);
        }

        public Result UpdateTask(string id, TaskDto taskDto)
        {
            var res = _mapper.TaskMapp(id, taskDto);
            
            var response = _repository.UpdateTask(res);

            if (response == null)
            {
                return Result.Fail("Task não encontrada!");
            }
            return Result.Ok();
        }

        public Result DeleteTask(string id)
        {
            var response = _repository.DeleteTask(id);

            if (response == null)
            {
                return Result.Fail("Task não encontrada!");
            }
            return Result.Ok();
        }
    }
}
