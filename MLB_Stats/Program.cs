﻿using System;
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


            //Stats.GetTodaysSchedule();                                    WORKS
            //Stats.GetScheduleForSpecifiedDates("20220504", "20220505");   WORKS
            //Stats.GetTodaysSchedule();                                    WORKS
            //Stats.getATeamsInfo("Yankees");
            //    menu();
            Stats.viewTeams();
            Stats.getATeamsInfo(140);



            //          await ProcessRepositories();
            Console.WriteLine("-------END OF MAIN-------");
            Console.ReadLine();
        }

       public static void menu()
        {
            // print out the menu and call the correct methods

            // Enter into specific categories...
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
