﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MLB_Stats
{
    internal class Stats
    {

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
    }   
}