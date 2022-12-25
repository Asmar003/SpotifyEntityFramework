using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class AMService
    {
        public ArtistMusic GetById(int id)
        {
            ArtistMusic artistMusic;
            using (AppDbContext dbContext = new AppDbContext())
            {
                artistMusic = dbContext.ArtistMusics.FirstOrDefault(am => am.Id == id);
            }
            return artistMusic;
        }
        public void CreateArtistMusic(int artistId,int musicId)
        {
            ArtistMusic artistMusic = new ArtistMusic
            {
                ArtistId = artistId,
                MusicId = musicId
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.ArtistMusics.Add(artistMusic);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            ArtistMusic existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.ArtistMusics.FirstOrDefault(am => am.Id == id);
                if (existed != null)
                {
                    dbContext.ArtistMusics.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<ArtistMusic> GetAll()
        {
            List<ArtistMusic> artistMusics;

            using (AppDbContext context = new AppDbContext())
            {
                artistMusics = context.ArtistMusics.ToList();
            }
            return artistMusics;
        }
        public void Update(int artistId, int musicId)
        {
            ArtistMusic artistMusic = new ArtistMusic()
            {
                ArtistId = artistId,
                MusicId = musicId
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.ArtistMusics.Update(artistMusic);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
