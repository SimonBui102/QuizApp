using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzWeb.AppDbContext;
using QuizzWeb.Model;

namespace QuizzWeb.Pages.Quizzes
{
    public class EditQuizModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Quiz Quiz { get; set; }

        public EditQuizModel(ApplicationDbContext db) {

            _db = db;

        
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Quiz = await _db.Quizzes
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Quiz == null)
            {
                return NotFound();
            }

            return Page();
        }


        public async  Task<IActionResult> OnPost() {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Quiz).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}
