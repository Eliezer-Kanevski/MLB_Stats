using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Stats
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {

            menu();
            //Stats.GetTodaysSchedule();                                    WORKS
            //Stats.GetScheduleForSpecifiedDates("20220504", "20220505");   WORKS
            //Stats.GetTodaysSchedule();                                    WORKS
            //Stats.getATeamsInfo("Yankees");
            //    menu();
            //Stats.viewTeams();
            //Stats.getATeamsInfo(140);
            Stats.getAllTeamsInfo();


            //          await ProcessRepositories();


            /* while (true)
             {
                 menu();
             }
            */




            Console.WriteLine("-------END OF MAIN-------");
            Console.ReadLine();
        }
        static User currentUser;
        public static void menu()
        {

            //***FACADE***
            int choice = 0;
            while (true)
            {
                // print out the menu and call the correct methods
                Console.WriteLine("Enter 0 to view how this application works");
                Console.WriteLine("Enter 1 to create an account");
                Console.WriteLine("Enter 2 to login to your account");
                Console.WriteLine("Enter 3 to delete your account");
                Console.WriteLine("Enter 4 to get every team's information");
                Console.WriteLine("Enter 5 to get your teams information");
                Console.WriteLine("Enter 6 to to get any teams information");
                Console.WriteLine("Enter 7 to get today's schedule");
                Console.WriteLine("Enter 8 to get a schedule for a specific set of dates");
                Console.WriteLine("Enter 9 to exit the program");
             /*   Console.WriteLine("Enter 10");
                Console.WriteLine("Enter 11");
                Console.WriteLine("Enter 12");
              */

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        getAppInfo();
                        break;
                    case 1:
                        addUser();
                        break;

                    case 2:
                        login();
                        break;

                    case 3:
                        deleteAccount();
                        break;
                    case 4:
                        Stats.getAllTeamsInfo();
                        break;
                    case 5:
                        if(currentUser == null)
                        {
                            Console.WriteLine("you need to first log in to your accoun\nt");
                            break;
                        }
                        Stats.getATeamsInfo(currentUser.FavoriteTeam);
                        break;
                    case 6:
                        Stats.viewTeams();
                        Console.WriteLine("Enter a team name or code");
                        dynamic team = Console.ReadLine();
                        Stats.getATeamsInfo(team);
                        break;
                    case 7:
                        Stats.GetTodaysSchedule();
                        break;
                    case 8:
                        Console.WriteLine("Enter a start and end date in the form YYYYMMDD");
                        String start = Console.ReadLine();
                        String end = Console.ReadLine();
                        Stats.GetScheduleForSpecifiedDates(start, end);
                        break;
                    case 9:
                        System.Environment.Exit(1);
                        break;
                    /*case 10:

                        break;
                    case 11:

                        break;
                    case 12:

                        break;
                    case 13:

                        break;
                        */





                }
            }

                // Enter into specific categories...
         }


        public static void getAppInfo()
        {
            Console.WriteLine("Information coming soon. ");
        }
            public static void addUser()
            {
                Console.WriteLine("Please enter a username");
                String userName = Console.ReadLine();
                Console.WriteLine("Please enter a password");
                String password = Console.ReadLine();
                Stats.viewTeams();
                int favorite;
                while (true)
                {
                    Console.WriteLine("Enter your favorite team's code");
                    favorite = Convert.ToInt32(Console.ReadLine());
                    if (Stats.teamCodes.ContainsValue(favorite))
                    {
                        break;
                    }

                }
                Console.WriteLine("To follow multiple teams, please enter as many team codes as desired. When completed, please enter 0");
                int codes = -1;
                List<int> teamsFollowing = new List<int>();
                while (codes != 0)
                {
                    Console.WriteLine("Enter code here: ");
                    codes = Convert.ToInt32(Console.ReadLine());
                    if (codes == 0) break;
                    teamsFollowing.Add(codes);
                }
                new User(userName, password, favorite, teamsFollowing);
            }



            public static void addUser(string password, int favoriteTeam, List<int> teamsFollowing)
            {
                Console.WriteLine("Please enter a username");
                String userName = Console.ReadLine();
                new User(userName, password, favoriteTeam, teamsFollowing);
            }


            public static void login()
            {
                while (true)
                {
                    Console.WriteLine("Please enter your username, then passwors separately.");
                    String username = Console.ReadLine();
                    String password = Console.ReadLine();


                    foreach (User user in User.users)
                    {
                        if (user.UserName == username && user.Password == password)
                        {
                            currentUser = user;
                            Console.WriteLine("successfully logged in\n");
                            return;
                        }

                    }
                    Console.WriteLine("Invalid user.");
                    Console.WriteLine("Enter menu if you want to go to the menu, otherwise, enter a key to try again.");
                    String leave = Console.ReadLine();
                    if (leave.ToLower() == "menu") break;
                }

            }

            public static void deleteAccount()
            {
                while (true)
                {
                    Console.WriteLine("Please enter your username, then passwors separately.");
                    String username = Console.ReadLine();
                    String password = Console.ReadLine();

                    foreach (User user in User.users)
                    {
                        if (user.UserName == username && user.Password == password)
                        {
                            currentUser = user;
                            User.users.Remove(user);
                            break;
                        }
                    }
                    Console.WriteLine("Invalid user, please try again");
                    Console.WriteLine("Enter menu if you cannot find the account and want to go to the menu, otherwise, enter a key to try again.");
                    String leave = Console.ReadLine();
                    if (leave.ToLower() == "menu") break;
                }

            }

             




            // See https://aka.ms/new-console-template for more information

            /*       private static async Task ProcessRepositories()
                   {
                       client.DefaultRequestHeaders.Accept.Clear();
                       client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                       client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                       //var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
                       var stringTask = client.GetStringAsync("http://gdx.mlb.com/components/game/mlb/year_2019/month_03/day_28/miniscoreboard.json");

                       var msg = await stringTask;
                       Console.Write(msg);

                       Console.ReadLine();

                   }
               */
        }



}
