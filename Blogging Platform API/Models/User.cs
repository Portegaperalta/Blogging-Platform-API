using System.ComponentModel.DataAnnotations;

namespace Blogging_Platform_API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The field {0} is required")]
        public required string Name { get; set; }
        [Required(ErrorMessage ="The field {0} is required")]
        public required string Email { get; set; }
        [Required(ErrorMessage ="The field {0} is required")]
        public required string Password { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
