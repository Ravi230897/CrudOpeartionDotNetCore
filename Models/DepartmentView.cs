using System.ComponentModel.DataAnnotations;

namespace CrudOpeartionDotNetCore.Models
{
    public class DepartmentView
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
