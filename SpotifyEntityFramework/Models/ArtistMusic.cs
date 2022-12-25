namespace SpotifyEntityFramework.Models
{
    internal class ArtistMusic
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int MusicId { get; set; }
        public Artist artist { get; set; }
        public Music music { get; set; }
    }
}
