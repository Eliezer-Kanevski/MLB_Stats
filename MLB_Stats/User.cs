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
        public String Password { get; private set; }
        public int FavoriteTeam { get; set; }
        public List<int> TeamsFollowing { get; set; }
        //public List<String> FavoritePlayers { get; set; }
        public static List<User> users = new List<User>();
    
        public User(string userName, string password, int favoriteTeam, List<int> teamsFollowing)
        {
            foreach(User user in users)
            {
                if (user.UserName == userName)
                {
                    Console.WriteLine("This username is already taken, please try a different username.");
                    Program.addUser(password, favoriteTeam, teamsFollowing);
                }
            }
                      
            UserName = userName;
            Password = password;
            FavoriteTeam = favoriteTeam;
            TeamsFollowing = teamsFollowing;
            //FavoritePlayers = favoritePlayers;

            
            users.Add(this);
        }


     }
}
