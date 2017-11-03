using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace identity_server {
  
  public class Program {
    
    public static void Main(string[] args) {
      Console.Title = "Sample Identity Server";
      BuildWebHost(args).Run();
    }

    private static IWebHost BuildWebHost(string[] args) => WebHost
      .CreateDefaultBuilder(args)
      .UseStartup<Startup>()
      .Build();
  }
}