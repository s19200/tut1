using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace tutorial1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var websiteURL = args[0];
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(websiteURL);
            if (response.IsSuccessStatusCode)
            { 
                var content = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(content);

                foreach (var email in matches)
                {
                    Console.WriteLine(email);
                }
            }
            Console.ReadKey();

        }
    }
}
