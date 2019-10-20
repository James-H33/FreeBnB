using Server.Models;
using Shared;
using AutoMapper;

namespace Server.Mappings
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<UserForRegister, User>();
    }
  }
}
