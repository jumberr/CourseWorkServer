using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int Creator { get; set; }
        
        [ForeignKey("Creator")]
        public Person Owner { get; set; }

        [Required]
        public string name_note { get; set; }
        public string groupName { get; set; }
        public string description_note { get; set; }
        
    }
}