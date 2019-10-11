using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Data;

namespace FreeBnB.Server
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        try
        {
          var context = services.GetRequiredService<DataContext>();
          context.Database.Migrate();
          Seed.SeedHomes(context);
        }
        catch (Exception ex)
        {
         Console.WriteLine(ex.Message);
        }
      }

      host.Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build())
            .UseStartup<Startup>()
            .Build();
  }
}
