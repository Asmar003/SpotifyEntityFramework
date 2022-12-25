namespace SpotifyEntityFramework.Models
{
    internal class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<Role> Roles { get; set; }
        public List<ArtistMusic> ArtistMusics { get; set; }
        public List<MusicPlaylist> MusicPlaylists { get; set; }
    }
}
