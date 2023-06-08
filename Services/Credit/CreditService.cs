using BeCleverChallenge.Models;
using BeCleverChallenge.Services.Credit.Dto;
using Microsoft.EntityFrameworkCore;

namespace BeCleverChallenge.Services.Credit
{
    public class CreditService : ICreditService
    {
        BeCleverContext _context;
        public CreditService(BeCleverContext context)
        {
            _context = context;
        }

        public List<PaymentTypeModel> GetAllPaymentType()
        {
            var allPayments = _context.PaymentType.ToList();

            if (allPayments != null)
            {
                return allPayments;
            }

            return null;
        }

        public List<CreditModel> GetCreditByClient(int id)
        {
            var allPayments = _context.Credit.Where(x => x.ClientId == id).ToList();

            if (allPayments != null)
            {
                return allPayments;
            }

            return null;
        }

        public decimal GetCreditQuote(int id)
        {
            CreditModel result = _context.Credit.Find(id);
            var pepe = DateTime.Now.Day;
            if(result.ExpirationDay > pepe)
            {
                return (decimal)result.Quote;
            } 
                var quoteTotal = result.Quote + (result.Quote * result.DelayInterestPercent * (pepe - result.ExpirationDay));
                return (decimal)quoteTotal;
            }

        public int AddPayment(AddPayment input)
        {
            var result = _context.Database.ExecuteSqlRaw($"SP_ALTA_PAGO {input.CreditId},{input.Amount},{input.PayType},'{input.OperationNumber}'");
            return result;
        }

        public int CreateCredit(InserCredit input)
        {
            var result = _context.Database.ExecuteSqlRaw($"SP_ALTA_CREDITO {input.Amount},{input.InterestPercent},{input.QuantityQuote},{input.Iva},{input.ExpirationDay},{input.DelayInterestPercent},{input.UserId},{input.ClientId}");
            return result;
        }

        public List<CreditReportModel> GetCreditReport(DateTime desde, DateTime hasta)
        {
            var result = _context.Set<CreditReportModel>().FromSqlRaw($"SP_PAYMENT_REPORT '{desde}', '{hasta}'").ToList();
            return result;
        }

    }
}
