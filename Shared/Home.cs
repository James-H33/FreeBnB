using System.Collections.Generic;

namespace FreeBnB.Shared
{
  public class Home
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Photo> Photos { get; set; }
  }
}
