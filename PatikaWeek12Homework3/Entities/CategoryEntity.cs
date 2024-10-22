using System.ComponentModel.DataAnnotations;

namespace PatikaWeek12Homework3.Entities
{
    public class CategoryEntity:BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<CompetitorEntity> Competitors { get; set; }
    }
}
