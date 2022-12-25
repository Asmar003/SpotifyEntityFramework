using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class UPService
    {
        public UserPlaylist GetById(int id)
        {
            UserPlaylist userPlaylist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                userPlaylist = dbContext.UserPlaylists.FirstOrDefault(up => up.Id == id);
            }
            return userPlaylist;
        }
        public void CreateUserPlaylist(int userId, int playlistId)
        {
            UserPlaylist userPlaylist = new UserPlaylist
            {
                PlaylistId = playlistId,
                UserId = userId,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.UserPlaylists.Add(userPlaylist);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            UserPlaylist existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.UserPlaylists.FirstOrDefault(up => up.Id == id);
                if (existed != null)
                {
                    dbContext.UserPlaylists.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<UserPlaylist> GetAll()
        {
            List<UserPlaylist> userPlaylists;

            using (AppDbContext context = new AppDbContext())
            {
                userPlaylists = context.UserPlaylists.ToList();
            }
            return userPlaylists;
        }
        public void Update(int userId, int playlistId)
        {
            UserPlaylist userPlaylist = new UserPlaylist()
            {
                UserId=userId,
                PlaylistId = playlistId
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.UserPlaylists.Update(userPlaylist);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
