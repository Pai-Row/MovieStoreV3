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
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/movie/GetGenreNames"));
        }

        internal async static Task<clsGenre> GetGenreAsync(string prGenreName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsGenre>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/movie/GetGenre?Name=" + prGenreName));
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> UpdateMovieAsync(clsAllMovie prMovie)
        {
            return await InsertOrUpdateAsync(prMovie, "http://localhost:60064/api/movie/PutMovie", "PUT");
        }

        internal async static Task<string> PostMovieAsync(clsAllMovie prMovie)
        {
            return await InsertOrUpdateAsync(prMovie, "http://localhost:60064/api/movie/PostMovie", "POST");
        }

        internal async static Task<string> DeleteMovieAsync(clsAllMovie prMovie)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/movie/DeleteMovie?MovieID={prMovie.MovieID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<List<string>> GetMovieTitlesAsync(string prTitle, bool prRentable)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync(string.Format("http://localhost:60064/api/movie/GetMovieTitles?Title={0}&Rentable={1}", prTitle, prRentable)));
        }
    }
}
