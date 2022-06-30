using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApiTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/geo/1.0/direct?q=Peshawar&limit=5&appid=b0e97d665f0fdf9cef8ef823df81161a");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetWeather(client).Wait();




        }





        static async Task GetWeather(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("");

                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string weather = await res.Content.ReadAsStringAsync();

                    JArray jobj = JArray.Parse(weather);
                    JToken jToken = jobj.First;


                    //For Json
                    Console.WriteLine(jToken.ToString());


                   // string WeatherState = jToken.First["name"]["state"]["country"].ToString();
                   // WeatherReport report =JsonConvert.DeserializeObject<WeatherReport>((string)jobj);


                    //For  Object
                    var report = JsonConvert.DeserializeObject<List<WeatherReport>>(weather);
                    Console.WriteLine("\n");

                    for (int i = 0; i < report.Count; i++)
                    {
                        
                        Console.WriteLine(report[i].name);
                        Console.WriteLine(report[i].country);
                        Console.WriteLine(report[i].state);
                        Console.WriteLine(report[i].lat);
                        Console.WriteLine(report[i].lon);
                    }                                
                   Console.ReadLine();
                }
            }
        }

    }
}
