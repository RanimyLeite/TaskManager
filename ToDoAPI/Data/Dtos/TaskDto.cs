using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Data.Dtos
{
    public class TaskDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Description { get; set; }
    }
}
