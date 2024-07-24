using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzWeb.AppDbContext;
using QuizzWeb.Model;

namespace QuizzWeb.Pages.Quizzes
{
    public class EditQuestionModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Question Question { get; set; }
        [BindProperty]
        public List<Answer> Answers { get; set; }

        public EditQuestionModel(ApplicationDbContext db) { 
        
            _db = db;
        
        
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Question = await _db.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(m => m.Id == id);


            Answers = Question.Answers.ToList();

            if (Question == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Question.Answers = Answers; 

            _db.Attach(Question).State = EntityState.Modified;

            foreach (var answer in Question.Answers)
            {
                _db.Attach(answer).State = EntityState.Modified;
            }


            if (Request.Form.TryGetValue("CorrectAnswer", out var correctAnswerValue))
            {
                int correctAnswerId = int.Parse(correctAnswerValue);
                foreach (var answer in Question.Answers)
                {
                    answer.RigtAnswer = answer.Id == correctAnswerId;
                }
            }



            await _db.SaveChangesAsync();
     
         

            return RedirectToPage("/Quizzes/EditQuiz", new { id = Question.QuizId });
        }





    }
}
