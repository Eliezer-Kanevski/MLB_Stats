using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Json.JsonSerializer;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

//*****************
//  create formatter class?
//  ***************

/*
 * The JsonSerializer.Deserialize() method converts a JSON string into 
 *     ----------------------------             
 * an object of the type specified by a generic type parameter.
*/
namespace MLB_Stats
{
    public class Stats
    {

        private Stats(){}

        public static  Dictionary<string, int> teamCodes = new Dictionary<string, int>()
        {
            {"Atlanta Braves", 144}, {"Miami Marlins", 146}, {"New York Mets", 121}, {"Philadelphia Phillies", 143}, {"Washington Nationals", 120}, 
            {"Chicago Cubs", 112}, {"Cincinnati Reds", 113}, {"Milwaukee Brewers", 158}, {"Pittsburgh Pirates", 134}, {"St. Louis Cardinals", 138},
            {"Arizona Diamondbacks", 109}, {"Colorado Rockies", 115}, {"Los Angeles Dodgers", 119}, {"San Diego Padres", 135}, {"San Francisco Giants", 137},
            {"Baltimore Orioles", 110}, {"Boston Red Sox", 111}, {"New York Yankees", 147}, {"Tampa Bay Rays", 139}, {"Toronto Blue Jays", 141},
            {"Chicago White Sox", 145}, {"Cleveland Guardians", 114}, {"Detroit Tigers", 116}, {"Kansas City Royals", 118}, {"Minnesota Twins", 142},
            {"Houston Astros", 117}, {"Los Angeles Angels", 108}, {"Oakland Athletics", 133}, {"Seattle Mariners", 136}, {"Texas Rangers", 140},
             // Adding without city
             {"Braves", 144}, {"Marlins", 146}, {"Mets", 121}, {"Phillies", 143}, {"Nationals", 120}, {"Cubs", 112}, {"Reds", 113}, {"Brewers", 158}, {"Pirates", 134}, {"Cardinals", 138},
            {"Diamondbacks", 109}, {"Rockies", 115}, {"Dodgers", 119}, {"Padres", 135}, {"Giants", 137}, {"Orioles", 110}, {"Red Sox", 111}, {"Yankees", 147}, {"Rays", 139}, {"Blue Jays", 141},
            {"White Sox", 145}, {"Guardians", 114}, {"Tigers", 116}, {"Royals", 118}, {"Twins", 142}, {"Astros", 117}, {"Angels", 108}, {"Athletics", 133}, {"Mariners", 136}, {"Rangers", 140},
        };



        private static readonly HttpClient client = new HttpClient();

       
        public static void getScoreboard()
        { 
            Console.WriteLine("Enter a year in the form yyyy, then enter a month in the form mm, and then enter a date in the form dd");
           
            DateTime date = DateTime.Now;
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            var msg = client.GetStringAsync("http://gdx.mlb.com/components/game/mlb/" + year + "/" + month + "/" + day + "/master_scoreboard.json");
            Console.WriteLine(msg);

        }

        public static async Task GetTodaysSchedule()
        {
            var stringTask = client.GetStringAsync("http://statsapi.mlb.com/api/v1/schedule/games/?sportId=1");
            var msg = await stringTask;

            // Need to format the msg.
            Console.Write(msg);

        }

        public static async Task GetScheduleForSpecifiedDates(String startDate, String endDate)
        {
            
            try
            {
                if (startDate.Length != 8 || endDate.Length != 8) { throw new Exception("Invalid dates"); }
                int sDay = Int32.Parse(startDate.Substring(6, 2));
                int sMonth = Int32.Parse(startDate.Substring(4, 2));
                int sYear = Int32.Parse(startDate.Substring(0, 4));
                int eDay = Int32.Parse(endDate.Substring(6, 2));
                int eMonth = Int32.Parse(endDate.Substring(4, 2));
                int eYear = Int32.Parse(endDate.Substring(0, 4));
                if (sDay < 1 || sDay > 31 || eDay < 1 || eDay > 31) { throw new Exception("Invalid day entered\n"); }
                if (sMonth < 1 || sMonth > 12 || eMonth < 1 || eMonth > 12) { throw new Exception("Invalid month entered\n"); }
                if (sYear < 2021 || sYear > 2022 || eYear < 2021 || eYear > 2022) { throw new Exception("Invalid year entered\n"); }
            }

            catch (Exception e) { Console.WriteLine(e.Message); }

            startDate = startDate.Substring(0, 4) + "-" + startDate.Substring(4,2) + "-" + startDate.Substring(6, 2);
            endDate = endDate.Substring(0,4) + "-" + endDate.Substring(4, 2) + "-" + endDate.Substring(6, 2);
            //  Need to test for valid input in the form yyyy, mm, dd
            var stringTask = client.GetStringAsync("http://statsapi.mlb.com/api/v1/schedule/games/?sportId=1&startDate=" + startDate + "&endDate=" + endDate);

            var msg = await stringTask;

            // Need to format the msg.
            Console.Write(msg);



        }

        public static async Task getATeamsInfo(String name)
        {
            // review to lower everything.
            if (teamCodes.ContainsKey(name))
            {
                int codes = teamCodes[name];
                var teamInfo = await client.GetStringAsync("https://statsapi.mlb.com/api/v1/teams/" + codes);
                //var team = await client.GetStringAsync("http://statsapi.mlb.com/api/v1/teams");
                Console.Write(teamInfo);
                return;
            }
            else
            {
                try
                {
                    int code =  Int32.Parse(name);
                    getATeamsInfo(code);
                }
                catch{
                    Console.WriteLine("Invalid team name or code.");
                }
            }

            Console.WriteLine("The name provided either has incorrect spelling, or the team does not exist. Please click to view the teams and try again.");

        }

        public static async Task getATeamsInfo(int code)
        {
            if (teamCodes.ContainsValue(code))
            {
                var teamInfo = await client.GetStringAsync("https://statsapi.mlb.com/api/v1/teams/" + code);
                Console.Write(teamInfo);

                

                return;
            }
            Console.WriteLine("The code you entered is incorrect, please click view the teams and codes again, and enter a correct team or code.");
        }

        public static async Task getAllTeamsInfo()
        {
            List<Object> teams = new List<object>();
            for (int i = 0; i < 30; i++)
            {

                int code = teamCodes.ElementAt(i).Value;
                teams.Add(await client.GetStringAsync("https://statsapi.mlb.com/api/v1/teams/" + code));
            }
            //just to test output.
            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }
            /*
            var sorted =
                    from value in teams
                    select value; // new { value };
            Console.WriteLine("-----------------------------");
            foreach (var val in sorted)
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine(val);
            }
            */
        }

        public static void viewTeams()
        {
            foreach(KeyValuePair<String, int> kvp in teamCodes)
            {
                Console.WriteLine(kvp);
            }
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("The above gives 2 ways to enter a team name to view it's information. You can either enter a teams name, or its city and name together.");
            Console.WriteLine("Alternatively, you can enter the team code to view the team's information");
        }

       

    }   
}
