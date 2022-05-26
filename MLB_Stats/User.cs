using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Stats
{
    public class User
    {
        //---PROXY---
        public String UserName { get; private set; }
        public String Password { get; private set; }
        public int FavoriteTeam { get; set; }
        public List<int> TeamsFollowing { get; set; }
        //public List<String> FavoritePlayers { get; set; }
        public static List<User> users = new List<User>();
    
        //transform password to hash
        public User(string userName, string password, int favoriteTeam, List<int> teamsFollowing)
        {
            foreach(User user in users)
            {
                if (user.UserName == userName)
                {
                    Console.WriteLine("This username is already taken, please try a different username.");
                    Program.addUser(password, favoriteTeam, teamsFollowing);
                    break;
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
