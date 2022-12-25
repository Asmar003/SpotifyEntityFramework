using Microsoft.EntityFrameworkCore;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.DAL
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=ASMAR\\SQLEXPRESS;database=Spotify;Integrated security=true;trusted_connection=true;Encrypt=false");
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ArtistMusic> ArtistMusics { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylists { get; set; }
        public DbSet<UserPlaylist> UserPlaylists { get; set; }
    }
}
