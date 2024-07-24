using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzWeb.AppDbContext;
using QuizzWeb.Model;

namespace QuizzWeb.Pages.Quizzes
{
    public class UserScoresModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IList<ScoreUser> ScoreUsers { get; set; }


        public UserScoresModel(ApplicationDbContext db) { 
        
            _db = db;
        }
        public  void OnGet()
        {

            ScoreUsers =   _db.ScoreUsers.Include(s => s.Quiz).ThenInclude(q=> q.Questions).ToList();


        }
    }
}
