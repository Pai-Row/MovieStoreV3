using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Net.Http.Headers;

namespace MovieSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up server configuration
            Uri _baseAddress = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                                    defaults: new { id = RouteParameter.Optional }
        );
        // return JSON as default format
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                            new MediaTypeHeaderValue("text/html"));
        // Create server
        HttpSelfHostServer server = new HttpSelfHostServer(config);
        // Start listening
        server.OpenAsync().Wait();
        Console.WriteLine("Movie Web-API Self hosted on " + _baseAddress);
        Console.WriteLine("Hit ENTER to exit...");
        Console.ReadLine();
        server.CloseAsync().Wait();
        }
    }
}
