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
    internal class Stats
    {

        private static  Dictionary<string, int> teamCodes = new Dictionary<string, int>()
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
        

        // See https://aka.ms/new-console-template for more information

        private static readonly HttpClient client = new HttpClient();

        private static async Task ProcessRepositories()
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



        public static void getScorecard()
        {

        }

        public static async Task GetTodaysSchedule()
        {
            http://statsapi.mlb.com/api/v1/schedule/games/?sportId=1
            var stringTask = client.GetStringAsync("http://statsapi.mlb.com/api/v1/schedule/games/?sportId=1");

            var msg = await stringTask;

            // Need to format the msg.
            Console.Write(msg);

        }

        public static async Task GetScheduleForSpecifiedDates(String startDate, String endDate)
        {
            startDate = startDate.Substring(0, 4) + "-" + startDate.Substring(4,2) + "-" + startDate.Substring(6, 2);
            endDate = endDate.Substring(0,4) + "-" + endDate.Substring(4, 2) + "-" + endDate.Substring(6, 2);
            Console.WriteLine("Start statement " + startDate);
            Console.WriteLine("end date = " + endDate);
            //  Need to test for valid input in the form yyyy, mm, dd
            //    var stringTask = client.GetStringAsync("http://statsapi.mlb.com/api/v1/schedule/games/?sportId=1&startDate=" + year + "-" + month + "-" + day +"&endDate=2019-09-29");
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
            Console.WriteLine("The name provided either has incorrect spelling, or the team does not exist. Please click to view the teams and try again.");

        }

        public static async Task getATeamsInfo(int name)
        {
            if (teamCodes.ContainsValue(name))
            {
                var teamInfo = await client.GetStringAsync("https://statsapi.mlb.com/api/v1/teams/" + name);
                //var team = await client.GetStringAsync("http://statsapi.mlb.com/api/v1/teams");
                Console.Write(teamInfo);
                return;
            }
            Console.WriteLine("The code you entered is incorrect, please click view the teams and codes again, and enter a correct team or code.");
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
