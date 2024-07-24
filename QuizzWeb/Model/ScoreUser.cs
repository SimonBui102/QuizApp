using System.ComponentModel.DataAnnotations;

namespace QuizzWeb.Model
{
    public class ScoreUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]

        public int UserAge { get; set; }
        [Required]
        public int Score { get; set; }

        public Quiz? Quiz { get; set; }

        public int QuizId { get; set; }
    }
}
