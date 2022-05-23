using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Stats
{
    internal class User
    {
        public String UserName { get; set; }
        private String Password { get; set; }
        public String FavoriteTeam { get; set; }
        public List<String> TeamsFollowing { get; set; }
        public List<String> FavoritePlayers { get; set; }
    
        public User(string userName, string password, string favoriteTeam, List<string> teamsFollowing, List<string> favoritePlayers)
        {
            UserName = userName;
            Password = password;
            FavoriteTeam = favoriteTeam;
            TeamsFollowing = teamsFollowing;
            FavoritePlayers = favoritePlayers;
        }

     }
}
