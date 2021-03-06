using System.Collections.Generic;

namespace Server.Models
{
  public class Home
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Photo> Photos { get; set; }
  }
}
