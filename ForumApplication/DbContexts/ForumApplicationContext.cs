using ForumApplication.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApplication.API.DbContexts
{
    public class ForumApplicationContext :DbContext
    {
        public DbSet<Post> Posts { get; set; } = null!; // null-forgiving operator
        public DbSet<Comment> Comments { get; set; } = null!; // used to query and save instances of its entity type

        public ForumApplicationContext(DbContextOptions<ForumApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Post>()
               .HasData(
              new Post("New to Sweden")
              {
                  Id = 1,
                  Detail = "There is alot to learn about Sweden",
                  CreatedTime = DateTime.UtcNow.AddDays(-1)

              },
              new Post("Looking for work")
              {
                  Id = 2,
                  Detail = "No details available",
                  CreatedTime = DateTime.UtcNow.AddDays(-2)
              },
              new Post("Bio Madiha Gul")
              {
                  Id = 3,
                  Detail =@"Computer Engineer with 4 years of experience in C#.net 
                    web application development but I am open to learn new skills.
                    I came to Sweden 5 years ago and focused on learning Swedish. 
                    I have done internship at a start-up company called Yoin Technologies where
                    I worked as a backend developer and worked with Azure among other things.
                    Marcus Melberg, the CTO, was my supervisor at Yoin. Marcus is my refernce
                    and you are welcome to contact him to get more information. I like to learn new things
                    and I am looking for new challenges to further develop my knowlegde and skills. 
                    I want to contribute in the field of IT and increase my competance through work.
                    I am a hard working and ambitious woman who needs a chance to grow professionally",
                  CreatedTime = DateTime.UtcNow.AddHours(-3)
              });

            modelBuilder.Entity<Comment>().HasData(
                new Comment("The most sustainable city in the world - Gothenburg")
                {
                    Id = 1,
                    PostId = 1,
                    CreatedTime = DateTime.UtcNow.AddDays(-1).AddHours(1)
                },
               new Comment("I like it")
               {
                   Id = 2,
                   PostId = 1,
                   CreatedTime = DateTime.UtcNow.AddHours(-2)
               },
               new Comment("Good Luck")
               {
                   Id = 3,
                   PostId = 3,
                   CreatedTime = DateTime.UtcNow.AddHours(-1)
               }, 
               new Comment("Nice")
               {
                   Id = 4,
                   PostId = 1,
                   CreatedTime = DateTime.UtcNow.AddDays(-1).AddHours(1)
               }
                ) ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
