using System.Net.Http;
using System.Threading.Tasks;
using Services.Interfaces;
using FreeBnB.Shared;
using System.Text;
using Newtonsoft.Json;

namespace Services
{
  public class LoginService : ILoginService
  {

    private readonly HttpClient _http;

    public LoginService(HttpClient http)
    {
      _http = http;
    }

    public async Task<bool> Login(UserLoginDto loginDto)
    {
      try {
        var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
        var result = await _http.PostAsync("api/auth/login", content);
        var payload = await result.Content.ReadAsStringAsync();
        var token = JsonConvert.DeserializeObject<TokenDto>(payload);

        return token != null ? true : false;
      }
      catch
      {
        return false;
      }
    }
  }
}
