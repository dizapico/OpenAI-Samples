using Microsoft.Extensions.Hosting;
using OpenAI;
using OpenAI.Images;
using System.Reflection;

namespace Images
{
    public static class Program
    {
        

        public static async Task Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            var api = new OpenAIClient(OpenAIAuthentication.LoadFromDirectory(filename: $"./appSettings.{environment}.json"));

            Console.WriteLine("Insert prompt: ");
            var prompt = Console.ReadLine();

            var results = await api.ImagesEndPoint.GenerateImageAsync(prompt, 1, ImageSize.Small);

            Console.WriteLine(results[0]);
            
        }

    }
}