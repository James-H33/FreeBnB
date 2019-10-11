using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Data
{
  public class Seed
  {
    public static void SeedHomes(DataContext context)
    {
      if (!context.Homes.Any())
      {
        var homesData = File.ReadAllText("./Data/HomesSeedData.json");
        var homes = JsonConvert.DeserializeObject<List<Home>>(homesData);
        foreach (var home in homes)
        {
          context.Homes.Add(home);
        }

        context.SaveChanges();
      }
    }
  }
}
