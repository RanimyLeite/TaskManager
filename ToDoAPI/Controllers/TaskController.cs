using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data.Dtos;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;

        private readonly TaskService _service;

        public TaskController(ILogger<TaskController> logger, TaskService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<TaskModel> GetAllTasks()
        {
            _logger.LogInformation("Executando método GetAllTasks - método que lista todas as tasks do banco!");
            var result = _service.GetTasks();

            return result;
        }

        [HttpGet("{id}")]
        public TaskModel GetTaskById(string id)
        {
            _logger.LogInformation("Executando método GetTaskById - método que retorna uma task em especifico!");
            var result = _service.GetTaskById(id);

            return result;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskModel model)
        {
            _logger.LogInformation("Executando método CreateTask - método que cria uma task do banco!");
            _service.CreateTask(model);

            return Ok("Task criada com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(string id, [FromBody] TaskDto taskDto)
        {
            _logger.LogInformation("Executando método UpdateTask - método que atualiza uma tasks em especifico!");
            Result response = _service.UpdateTask(id, taskDto);

            if (response.IsFailed) return NotFound();

            return Ok("Task atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(string id)
        {
            _logger.LogInformation("Executando método DeleteTask - método que exclui uma task do banco!");
            Result response = _service.DeleteTask(id);

            if (response.IsFailed) return NotFound();

            return NoContent();
        }
    }
}

