using Server.Models;
using FreeBnB.Shared;
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
