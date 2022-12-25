namespace SpotifyEntityFramework.Models
{
    internal class MusicPlaylist
    {
        public int Id { get; set; }
        public int MusicId { get; set; }
        public int PlaylistId { get; set; }
        public Music music { get; set; }
        public Playlist playlist { get; set; }
    }
}
