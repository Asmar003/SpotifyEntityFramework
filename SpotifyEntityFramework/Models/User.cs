namespace SpotifyEntityFramework.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int RoleId { get; set; }
        public Role role { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<UserPlaylist> UserPlaylists { get; set; }
    }
}
