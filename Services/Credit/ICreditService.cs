using BeCleverChallenge.Models;
using BeCleverChallenge.Services.Credit.Dto;

namespace BeCleverChallenge.Services.Credit
{
    public interface ICreditService
    {
        List<CreditModel> GetCreditReport();
        decimal GetCreditQuote(int id);
        List<PaymentTypeModel> GetAllPaymentType();
        int CreateCredit(InserCredit input);
        int AddPayment(AddPayment input);

        List<CreditModel> GetCreditByClient(int id);
    }
}
