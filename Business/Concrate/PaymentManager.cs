using Business.Abstract;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Payment;
using Core.Utilities.Results;


namespace Business.Concrate
{
    public class PaymentManager : IPaymentService
    {
        //[ValidationAspect(typeof(FakePaymentValidator))]
        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        public IResult MakePayment(IPaymentModel paymentModel)
        {
            return new SuccessResult();
        }
    }
}
