using BeCleverChallenge.Models;
using BeCleverChallenge.Services.User.Dto;

namespace BeCleverChallenge.Services.User
{
    public interface IAutenticateService 
    {
        UserModel LoginService(UserLogin input);
        string Generate(UserModel userModel);

    }
}
