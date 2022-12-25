using Microsoft.EntityFrameworkCore;
using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class ArtistService
    {
        public Artist GetById(int id)
        {
            Artist artist;
            using (AppDbContext dbContext = new AppDbContext())
            {
                artist = dbContext.Artists.Include(a => a.ArtistMusics).FirstOrDefault(a => a.Id == id);
            }
            return artist;
        }
        public ArtistMusic GetArtistMusicById(int id)
        {
            ArtistMusic artistMusic;
            using (AppDbContext dbContext = new AppDbContext())
            {
                artistMusic = dbContext.ArtistMusics.Include(am => am.artist).FirstOrDefault(am => am.Id == id);
            }
            return artistMusic;
        }
        public void CreateArtist(string name, string surname,string birthday,string gender)
        {
            Artist artist = new Artist
            {
                Name = name,
                Surname = surname,
                Birthday = birthday,
                Gender = gender
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Artists.Add(artist);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            Artist existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.Artists.FirstOrDefault(p => p.Id == id);
                if (existed != null)
                {
                    dbContext.Artists.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<Artist> GetAll()
        {
            List<Artist> artists;

            using (AppDbContext context = new AppDbContext())
            {
                artists = context.Artists.ToList();
            }
            return artists;
        }
        public void Update(string name, string surname, string birthday, string gender)
        {
            Artist artist = new Artist()
            {
                Name=name,
                Surname=surname,
                Gender=gender,
                Birthday=birthday,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Artists.Update(artist);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
