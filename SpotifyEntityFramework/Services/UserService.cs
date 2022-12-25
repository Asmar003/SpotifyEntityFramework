using Microsoft.EntityFrameworkCore;
using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class UserService
    {
        public User GetById(int id)
        {
            User user;
            using (AppDbContext dbContext = new AppDbContext())
            {

                user = dbContext.Users.Include(u => u.Playlists).Include(u => u.UserPlaylists).FirstOrDefault(u => u.Id == id);
            }
            return user;
        }
        public Playlist GetPlaylistById(int id)
        {
            Playlist playlist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                playlist = dbContext.Playlists.Include(r => r.user).FirstOrDefault(p => p.Id == id);
            }
            return playlist;
        }
        public UserPlaylist GetUserPlaylistById(int id)
        {
            UserPlaylist userPlaylist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                userPlaylist = dbContext.UserPlaylists.Include(up => up.user).FirstOrDefault(up => up.Id == id);
            }
            return userPlaylist;
        }
        public void CreateUser(string name,string surname,string username,string password,string gender)
        {
            User user = new User
            {
                Name = name,
                Surname = surname,
                Username = username,
                Password = password,
                Gender = gender
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            User existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.Users.FirstOrDefault(u => u.Id == id);
                if (existed != null)
                {
                    dbContext.Users.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<User> GetAll()
        {
            List<User> users;

            using (AppDbContext context = new AppDbContext())
            {
                users = context.Users.ToList();
            }
            return users;
        }
        public void Update(string name, string surname, string username, string password, string gender)
        {
            User user = new User()
            {
                Name=name,
                Surname=surname,
                Username=username,
                Password=password,
                Gender=gender
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Users.Update(user);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
