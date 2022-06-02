using MonkeyFinderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinderApp.Services
{

    public class MonkeyService
    {
        HttpClient httpClient;
        public MonkeyService()
        {
            this.httpClient = new();
        }

        List<Monkey> monkeyList = new();
        public async Task<List<Monkey>> GetMonkeys()
        {
            if(monkeyList?.Count > 0)
                return monkeyList;

            // Online
            var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            //Offline
            /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);*/

            return monkeyList;

        }
    }
}
