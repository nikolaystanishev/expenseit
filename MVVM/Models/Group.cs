
using System.ComponentModel.DataAnnotations;

namespace expensit.MVVM.Models
{
    public class Group
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Color { get; set; }
    }
}
