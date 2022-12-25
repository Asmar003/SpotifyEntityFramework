namespace SpotifyEntityFramework.Models
{
    internal class UserPlaylist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlaylistId { get; set; }
        public User user { get; set; }
        public Playlist playlist { get; set; }
    }
}
