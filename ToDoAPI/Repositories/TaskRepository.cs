using Dapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ToDoAPI.Data.Dtos;
using ToDoAPI.Data.Interfaces;
using ToDoAPI.Models;
using static Dapper.SqlMapper;

namespace ToDoAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private IConfiguration _configuration;

        private string _connection => _configuration.GetConnectionString("UsuarioConnection");

        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<TaskModel> GetTasks()
        {
            using (var connection = new MySqlConnection(_connection))
            {
                return (List<TaskModel>)connection.Query<TaskModel>("SELECT * FROM Task");
            }
        }

        public TaskModel GetTaskById(string id)
        {
            using (var connection = new MySqlConnection(_connection))
            {
                var response = connection.Query<TaskModel>("SELECT * FROM Task WHERE Id = @id", new { Id = id }).FirstOrDefault();

                if(response == null)
                {
                    return null;
                }

                return response;
            }
        }

        public void CreateTask(TaskModel model)
        {
            try
            {
                Guid newId = Guid.NewGuid();
                using (var connection = new MySqlConnection(_connection))
                {
                    connection.Execute("INSERT INTO Task VALUES (@Id, @Title, @Description, @CreatedDate, @UpdatedDate)", new
                    {
                        Id = newId,
                        Title = model.Title,
                        Description = model.Description,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Result UpdateTask(TaskModel task)
        {
            try
            {
                using (var connection = new MySqlConnection(_connection))
                {
                    connection.Execute("UPDATE Task SET Title = @Title, Description = @Description, UpdatedDate = @UpdatedDate WHERE Id = @Id", new
                    {
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        UpdatedDate = task.UpdatedDate
                    });
                }

                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Result DeleteTask(string id)
        {
            using (var connection = new MySqlConnection(_connection))
            {
                connection.Execute("DELETE FROM Task WHERE Id = @Id", new
                {
                    Id = id
                });
            }

            return Result.Ok();
        }
    }
}
