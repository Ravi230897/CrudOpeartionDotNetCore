using System.ComponentModel.DataAnnotations;

namespace CrudOpeartionDotNetCore.Data
{
    public class Department
    {
       
        
            [Key]
            public int DepartmentId { get; set; }
            public string Name { get; set; }
        
    }
}
