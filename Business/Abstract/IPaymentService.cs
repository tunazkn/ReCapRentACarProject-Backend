using Core.Entities.Concrete.Payment;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult MakePayment(IPaymentModel paymentModel);
    }
}
