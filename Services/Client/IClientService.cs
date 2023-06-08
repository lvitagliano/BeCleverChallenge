using BeCleverChallenge.Models;
using BeCleverChallenge.Services.User.Dto;

namespace BeCleverChallenge.Services.Client
{
    public interface IClientService
    {
        List<ClientModel> GetAll();
        ClientModel GetById(int Id);
    }
}
