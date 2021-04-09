using Busines.Abstract;
using Busines.Constants;
using Core.Utilities.Results;
using DateAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
