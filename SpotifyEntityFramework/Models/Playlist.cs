namespace SpotifyEntityFramework.Models
{
    internal class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public List<MusicPlaylist> MusicPlaylists { get; set; }
        public List<UserPlaylist> UserPlaylists { get; set; }
    }
}
