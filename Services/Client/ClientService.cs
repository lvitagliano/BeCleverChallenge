using BeCleverChallenge.Models;

namespace BeCleverChallenge.Services.Client
{
    public class ClientService : IClientService
    {
        BeCleverContext _context;
        public ClientService(BeCleverContext context)
        {
            _context = context;
        }
        public List<ClientModel> GetAll()
        {
            var allClient = _context.Client.ToList();

            if (allClient != null)
            {
                return allClient;
            }

            return null;
        }

        public ClientModel GetById(int Id)
        {
            var client = _context.Client.Find(Id);

            if (client != null)
            {
                return client;
            }

            return null;
        }
    }
}
