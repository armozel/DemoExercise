using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExercise.Context.Entities
{
    [Table("UserLoginHistory")]
    public class UserLoginHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime DateLogged { get; set; }
    }
}
