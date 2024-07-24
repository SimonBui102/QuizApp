using System.ComponentModel.DataAnnotations;

namespace QuizzWeb.Model
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public bool RigtAnswer { get; set; }

        public Question? Question { get; set; }
   
        public int QuestionId { get; set; }



    }
}
