namespace Server.Models
{
  public class Photo
  {
    public int Id { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public Home Home { get; set; }
    public int HomeId { get; set; }
  }
}
