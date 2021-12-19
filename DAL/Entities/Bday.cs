using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("BdayList")]
    public class Bday
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int Creator { get; set; }
        
        [ForeignKey("Creator")]
        public Person Owner { get; set; }
        
        [Required]
        public string name_Bday { get; set; }
        
        public string date_Bday { get; set; }
        
        public string phone_num_Bday { get; set; }
        
        public string addition_Bday { get; set; }
    }
}