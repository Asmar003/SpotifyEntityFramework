using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class MPService
    {
        public MusicPlaylist GetById(int id)
        {
            MusicPlaylist musicPlaylist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                musicPlaylist = dbContext.MusicPlaylists.FirstOrDefault(mp => mp.Id == id);
            }
            return musicPlaylist;
        }
        public void CreateMusicPlaylist(int musicId, int playlistId)
        {
            MusicPlaylist musicPlaylist = new MusicPlaylist
            {
                PlaylistId = playlistId,
                MusicId = musicId
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.MusicPlaylists.Add(musicPlaylist);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            MusicPlaylist existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.MusicPlaylists.FirstOrDefault(mp => mp.Id == id);
                if (existed != null)
                {
                    dbContext.MusicPlaylists.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<MusicPlaylist> GetAll()
        {
            List<MusicPlaylist> musicPlaylists;

            using (AppDbContext context = new AppDbContext())
            {
                musicPlaylists = context.MusicPlaylists.ToList();
            }
            return musicPlaylists;
        }
        public void Update(int playlistId, int musicId)
        {
            MusicPlaylist musicPlaylist = new MusicPlaylist()
            {
                PlaylistId = playlistId,
                MusicId = musicId
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.MusicPlaylists.Update(musicPlaylist);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
