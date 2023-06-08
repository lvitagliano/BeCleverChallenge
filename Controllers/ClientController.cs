using BeCleverChallenge.Models;
using BeCleverChallenge.Services.Client;
using BeCleverChallenge.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeCleverChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAllClient()
        {
            return Ok(_clientService.GetAll());
        }

        [HttpGet]
        public IActionResult GetClientById(int Id)
        {
            return Ok(_clientService.GetById(Id));
        }

    }
}
