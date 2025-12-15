using System.ComponentModel.DataAnnotations;

namespace Blogging_Platform_API.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="The field {0} is required")]
        [StringLength(30,ErrorMessage ="The maximum length for a username is 30 characters")]
        public required string Name { get; set; }
        
        [Required(ErrorMessage ="The field {0} is required")]
        [EmailAddress]
        [StringLength(254,ErrorMessage ="The maximum length for an email address is 254 characters")]
        public required string Email { get; set; }
        
        [Required(ErrorMessage ="The field {0} is required")]
        [MaxLength(255,ErrorMessage ="The maximun length for a password is 255 characters")]
        [MinLength(8,ErrorMessage ="Passwords must contain 8 characters or more")]
        public required string Password { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
