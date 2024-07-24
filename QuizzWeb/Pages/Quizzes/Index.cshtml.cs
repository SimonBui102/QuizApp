using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzWeb.AppDbContext;
using QuizzWeb.Model;

namespace QuizzWeb.Pages.Quizzes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Quiz> Quizzes { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {


            Quizzes = _db.Quizzes.Include(q => q.Questions);


        }
    }
}
