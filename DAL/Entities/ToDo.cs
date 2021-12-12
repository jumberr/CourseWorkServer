using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("TODOlist")]
    public class ToDo
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int CreatorID { get; set; }
        
        [ForeignKey("CreatorID")]
        public Person Creator { get; set; }
        
        [Required]
        public string Name_ToDo { get; set; }
        
        public string end_date_ToDo { get; set; }
        
        public bool status_ToDo { get; set; }
        
        public string description_ToDo { get; set; }
    }
}