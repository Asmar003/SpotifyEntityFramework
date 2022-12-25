using Microsoft.EntityFrameworkCore;
using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class CategoryServices
    {
        public Category GetById(int id)
        {
            Category category;
            using (AppDbContext dbContext = new AppDbContext())
            {
                category = dbContext.Categories.Include(c => c.Musics).FirstOrDefault(c => c.Id == id);
            }
            return category;
        }
        public Music GetMusicById(int id)
        {
            Music music;
            using (AppDbContext dbContext = new AppDbContext())
            {
                music = dbContext.Musics.Include(m => m.category).FirstOrDefault(m => m.Id == id);
            }
            return music;
        }
        public void CreateCategory(string name)
        {
            Category category = new Category
            {
                Name = name
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            Category existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.Categories.FirstOrDefault(c => c.Id == id);
                if (existed != null)
                {
                    dbContext.Categories.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<Category> GetAll()
        {
            List<Category> categories;

            using (AppDbContext context = new AppDbContext())
            {
                categories = context.Categories.ToList();
            }
            return categories;
        }
        public void Update(string name)
        {
            Category category = new Category()
            {
                Name = name
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Categories.Update(category);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
