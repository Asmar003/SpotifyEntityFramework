namespace SpotifyEntityFramework.Models
{
    internal class Role
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int MusicId { get; set; }
        public Music music { get; set; }
    }
}
