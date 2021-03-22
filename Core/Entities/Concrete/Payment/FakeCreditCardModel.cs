using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.Payment
{
    public class FakeCreditCardModel : IPaymentModel
    {
        public string CardHolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
    }
}
