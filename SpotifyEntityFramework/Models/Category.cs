namespace SpotifyEntityFramework.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Music> Musics { get; set; }
    }
}
