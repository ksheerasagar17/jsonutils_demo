using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using jsonutils_demo.Model.JSONUtils;
using System.Collections.Generic;
using System;

namespace jsonutils_demo
{
    public class Program
    {
        public static void Main()
        {
            //Get all Powerball Winning Information to display.
            var powerBallDraws = GetEmployeeInfoAsync().Result;
            if (powerBallDraws != null)
            {
                Console.WriteLine("Date,Multiplier,WinningNumbers");
                foreach (var powerBallDraw in powerBallDraws)
                {
                    Console.WriteLine("{0},{1},{2}", powerBallDraw.DrawDate.ToString("MM/dd/yyyy"), powerBallDraw.Multiplier, powerBallDraw.WinningNumbers);
                }
            }
            else
            {
                Console.WriteLine("Not found Powerball Winning Draws till today from government website");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Gets all Powerball Winning Draws till today from government website.
        /// </summary>
        /// <returns>Returns all Powerball Winning Draws information</returns>
        private static async Task<List<PowerballDraw>> GetEmployeeInfoAsync()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://data.ny.gov")
            };

            //Setting up HTTP GET url.
            var response = await client.GetAsync("resource/8vkr-v8vh.json");

            //Checking if response is successful.
            if (response.IsSuccessStatusCode)
            {
                //Reading content as string from response.
                var jsonString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    //Deserializing to C# Object.
                    return JsonConvert.DeserializeObject<List<PowerballDraw>>(jsonString);
                }
            }
            return null;
        }
    }
}