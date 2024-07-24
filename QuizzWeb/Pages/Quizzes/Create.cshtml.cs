using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizzWeb.AppDbContext;
using QuizzWeb.Model;

namespace QuizzWeb.Pages.Quizzes
{

    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public String QuizTitle { get; set; }

        public int NumQuestions { get; set; }

        public List<QuestionInputModel> Questions { get; set; }


        public class QuestionInputModel { 
            
            public String Text { get; set; }

            public List<AnswerInputModel> Answers { get; set; }
            public int CorrectAnswer { get; set; }
        
        
        
        }

        public class AnswerInputModel { 
        
            public string Text { get; set; }
        
        }
        


        public CreateModel(ApplicationDbContext db) {

            _db = db;

        }


        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync() { 
        

            if (!ModelState.IsValid)
            {
                 return Page(); 
            }

            var quiz = new Quiz
            {
                Name = QuizTitle,

                Questions = new List<Question>()

            };

            foreach (var questionInput in Questions)
            {
                var question = new Question
                {
                    Content = questionInput.Text,
                    Answers = new List<Answer>()


                };

                for (int i = 0; i < questionInput.Answers.Count; i++) {
                    question.Answers.Add(new Answer {
                        Content = questionInput.Answers[i].Text,
                        RigtAnswer = i == questionInput.CorrectAnswer
                    });
                
                
                }

                quiz.Questions.Add(question);
            
            
            
            }

         

            _db.Quizzes.Add(quiz);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");

        
        
        }
    }
}
