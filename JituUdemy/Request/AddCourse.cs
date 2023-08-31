using JituUdemy.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace JituUdemy.Request
{
    public class AddCourse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public Guid InstructorId { get; set; } = default!;
    }
}
