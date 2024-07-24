using System.ComponentModel.DataAnnotations;

namespace QuizzWeb.Model
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
