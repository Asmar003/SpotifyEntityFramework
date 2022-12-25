namespace SpotifyEntityFramework.Models
{
    internal class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public List<ArtistMusic> ArtistMusics { get; set; }
    }
}
