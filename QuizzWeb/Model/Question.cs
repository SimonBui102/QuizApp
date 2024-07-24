using System.ComponentModel.DataAnnotations;

namespace QuizzWeb.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public Quiz? Quiz { get; set; }

     
        public int QuizId { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
