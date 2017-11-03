using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace api {
  
  public class Program {
  
    public static void Main(string[] args) {
      Console.Title = "Secure Test API";
      BuildWebHost(args).Run();
    }

    private static IWebHost BuildWebHost(string[] args) => WebHost
      .CreateDefaultBuilder(args)
      .UseUrls("http://localhost:5001")
      .UseStartup<Startup>()
      .Build();
  }
}