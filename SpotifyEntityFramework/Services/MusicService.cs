using Microsoft.EntityFrameworkCore;
using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class MusicService
    {
        public Music GetById(int id)
        {
            Music music;
            using (AppDbContext dbContext = new AppDbContext())
            {

                music = dbContext.Musics.Include(m => m.Roles).Include(m => m.ArtistMusics).Include(m => m.MusicPlaylists).FirstOrDefault(m => m.Id == id);
            }
            return music;
        }
        public Role GetRoleById(int id)
        {
            Role role;
            using (AppDbContext dbContext = new AppDbContext())
            {
                role = dbContext.Roles.Include(r => r.music).FirstOrDefault(r => r.Id == id);
            }
            return role;
        }
        public ArtistMusic GetArtistMusicById(int id)
        {
            ArtistMusic artistMusic;
            using (AppDbContext dbContext = new AppDbContext())
            {
                artistMusic = dbContext.ArtistMusics.Include(am => am.music).FirstOrDefault(am => am.Id == id);
            }
            return artistMusic;
        }
        public MusicPlaylist GetMusicPlaylistById(int id)
        {
            MusicPlaylist musicPlaylist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                musicPlaylist = dbContext.MusicPlaylists.Include(mp => mp.music).FirstOrDefault(mp => mp.Id == id);
            }
            return musicPlaylist;
        }
        public void CreateMusic(string name,int duration)
        {
            Music music = new Music
            {
                Name = name,
                Duration = duration,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Musics.Add(music);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            Music existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.Musics.FirstOrDefault(m => m.Id == id);
                if (existed != null)
                {
                    dbContext.Musics.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<Music> GetAll()
        {
            List<Music> musics;

            using (AppDbContext context = new AppDbContext())
            {
                musics = context.Musics.ToList();
            }
            return musics;
        }
        public void Update(string name,int duration)
        {
            Music music = new Music()
            {
                Name=name,
                Duration=duration,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Musics.Update(music);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
