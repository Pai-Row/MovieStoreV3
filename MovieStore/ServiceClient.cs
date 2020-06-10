using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MovieStore
{
    public static class ServiceClient
    {
        internal async static Task<List<string>> GetGenreNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/movie/GetGenreNames/"));
        }

        internal async static Task<clsGenre> GetGenreAsync(string prGenreName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsGenre>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/gallery/GetGenre?Name=" + prGenreName));
        }

    }
}
