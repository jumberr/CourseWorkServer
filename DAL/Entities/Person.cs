using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("UsersCredentials")]
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "password")]
        public string Password { get; set; }
    }
}