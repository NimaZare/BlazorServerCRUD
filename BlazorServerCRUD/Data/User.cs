using System.ComponentModel.DataAnnotations;

namespace BlazorServerCRUD.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; } = string.Empty;
    }
}
