using BeCleverChallenge.Services.Credit;
using BeCleverChallenge.Services.Credit.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeCleverChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class CreditController : ControllerBase
    {
        ICreditService _creditService;
        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            return Ok(_creditService.GetAllPaymentType());
        }

        [HttpGet]
        public IActionResult GetCreditByClient(int Id)
        {
            return Ok(_creditService.GetCreditByClient(Id));
        }

        [HttpPost]
        public IActionResult GetCreditQuote(int Id)
        {
            return Ok(_creditService.GetCreditQuote(Id));
        }

        [HttpPost]
        public IActionResult CreateCredit(InserCredit input)
        {
            return Ok(_creditService.CreateCredit(input));
        }

        [HttpPost]
        public IActionResult AddPayment(AddPayment input)
        {
            return Ok(_creditService.AddPayment(input));
        }

        [HttpGet]
        public IActionResult GetCreditReport(DateTime desde, DateTime hasta)
        {
            return Ok(_creditService.GetCreditReport(desde, hasta));
        }
    }
}
