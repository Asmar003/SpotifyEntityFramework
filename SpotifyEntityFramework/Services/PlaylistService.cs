using Microsoft.EntityFrameworkCore;
using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class PlaylistService
    {
        public Playlist GetById(int id)
        {
            Playlist playlist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                playlist = dbContext.Playlists.Include(p => p.MusicPlaylists).Include(p => p.UserPlaylists).FirstOrDefault(p => p.Id == id);
            }
            return playlist;
        }
        public MusicPlaylist GetMusicPlaylistById(int id)
        {
            MusicPlaylist musicPlaylist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                musicPlaylist = dbContext.MusicPlaylists.Include(mp => mp.playlist).FirstOrDefault(mp => mp.Id == id);
            }
            return musicPlaylist;
        }
        public UserPlaylist GetUserPlaylistById(int id)
        {
            UserPlaylist userPlaylist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                userPlaylist = dbContext.UserPlaylists.Include(up => up.playlist).FirstOrDefault(up => up.Id == id);
            }
            return userPlaylist;
        }
        public void CreatePlaylist(string name)
        {
            Playlist playlist = new Playlist
            {
                Name = name,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Playlists.Add(playlist);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            Playlist existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.Playlists.FirstOrDefault(p => p.Id == id);
                if (existed != null)
                {
                    dbContext.Playlists.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<Playlist> GetAll()
        {
            List<Playlist> playlists;

            using (AppDbContext context = new AppDbContext())
            {
                playlists = context.Playlists.ToList();
            }
            return playlists;
        }
        public void Update(string name)
        {
            Playlist playlist = new Playlist()
            {
                Name = name,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Playlists.Update(playlist);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
