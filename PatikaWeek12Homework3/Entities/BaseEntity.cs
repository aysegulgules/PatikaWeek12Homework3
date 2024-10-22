using System.ComponentModel.DataAnnotations;

namespace PatikaWeek12Homework3.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;            
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public  DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Boolean IsDeleted { get; set; }


    }
}
