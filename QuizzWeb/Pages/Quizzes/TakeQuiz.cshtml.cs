using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzWeb.AppDbContext;
using QuizzWeb.Model;
using System.ComponentModel.DataAnnotations;

namespace QuizzWeb.Pages.Quizzes
{
    public class TakeQuizModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [BindProperty]
        [Display(Name = "User Age")]
        [Range(1, 100, ErrorMessage = "The number of questions must be at least 1.")]
        public int UserAge  { get; set; }

        public Quiz Quiz { get; set; }

        public TakeQuizModel(ApplicationDbContext db) { 
        
            _db= db;
        
        
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Quiz = await _db.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (Quiz == null)
            {
                return NotFound();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            Quiz = await _db.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (Quiz == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            int score = 0;
            foreach (var question in Quiz.Questions)
            {
                if (Request.Form.TryGetValue($"Questions[{question.Id}]", out var answerIdStr))
                {
                    int answerId = int.Parse(answerIdStr);
                    var selectedAnswer = question.Answers.First(a => a.Id == answerId);
                    if (selectedAnswer.RigtAnswer)
                    {
                        score++;
                    }
                }
            }

            var scoreUser = new ScoreUser
            {
                UserName = UserName,
                UserAge = UserAge,
                Score = score,
                QuizId = Quiz.Id
            };

            _db.ScoreUsers.Add(scoreUser);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Quizzes/UserScores");
        }





    }
}
