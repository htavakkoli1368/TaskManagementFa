using System.ComponentModel.DataAnnotations;

namespace TaskManagementFa.DTOs
{
    public class CreateTaskItemDto
    {
        [Required]
        [MaxLength(2)]
        public string TaskName { get; set; }
        [Required]
        [MaxLength(2)]
        public string Desc { get; set; }
    }
}
