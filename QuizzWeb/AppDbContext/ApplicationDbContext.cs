using Microsoft.EntityFrameworkCore;
using QuizzWeb.Model;

namespace QuizzWeb.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<ScoreUser> ScoreUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quiz>().HasMany(q => q.Questions).WithOne(q => q.Quiz).HasForeignKey(q => q.QuizId);
            modelBuilder.Entity<Question>().HasMany(q => q.Answers).WithOne(q => q.Question).HasForeignKey(q => q.QuestionId);

            //Seed Quiz:
            modelBuilder.Entity<Quiz>().HasData(

                new Quiz { Id = 1, Name = "Math Questions" }

                );

            modelBuilder.Entity<Question>().HasData(

                new Question { Id = 1, Content = " 2+3=?", QuizId = 1 },
                new Question { Id = 2, Content = "3*3=?", QuizId = 1 }

                );

            modelBuilder.Entity<Answer>().HasData(

                new Answer { Id = 1, Content = "4", RigtAnswer = false, QuestionId = 1 },
                new Answer { Id = 2, Content = "5", RigtAnswer = true, QuestionId = 1 },
                new Answer { Id = 3, Content = "6", RigtAnswer = false, QuestionId = 1 },
                new Answer { Id = 4, Content = "7", RigtAnswer = false, QuestionId = 1 },
                new Answer { Id = 5, Content = "7", RigtAnswer = false, QuestionId = 2 },
                new Answer { Id = 6, Content = "8", RigtAnswer = false, QuestionId = 2 },
                new Answer { Id = 7, Content = "9", RigtAnswer = true, QuestionId = 2 },
                new Answer { Id = 8, Content = "10", RigtAnswer = false, QuestionId = 2 }


                );
        }

    }
}
