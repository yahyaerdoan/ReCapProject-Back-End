using Busines.Abstract;
using Busines.Constants;
using Busines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DateAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Concrete
{
    public class CardPaymentManager : ICardPaymentService
    {
        private readonly ICardPaymentDal _cardPaymentdDal;

        public CardPaymentManager(ICardPaymentDal cardPaymentdDal)
        {
            _cardPaymentdDal = cardPaymentdDal;
        }


        [ValidationAspect(typeof(CardPaymentValidator))]
        public IResult Add(CardPayment cardPayment)
        {
            IResult result = BusinessRules.Run(CheckCreditCardNumber(cardPayment.CreditCardNumber));
            if (result != null)
            {
                return result;
            }            

            _cardPaymentdDal.Add(cardPayment);
            return new SuccessResult(Messages.CardPaymentsAdded);
        }

        public IResult Delete(CardPayment cardPayment)
        {
            _cardPaymentdDal.Delete(cardPayment);
            return new SuccessResult(Messages.CardPaymentsDeleted);
        }

        public IDataResult<List<CardPayment>> GetAll()
        {            
            return new SuccessDataResult<List<CardPayment>>(_cardPaymentdDal.GetAll(),Messages.CardPaymentsListed);
        }

        public IDataResult<CardPayment> GetCardPaymetsByCustomerId(int customerId)
        {
            return new SuccessDataResult<CardPayment>(_cardPaymentdDal.Get(c => c.CustomerId == customerId),Messages.GetCardPaymetsByCustomerId);
        }

        public IResult Update(CardPayment cardPayment)
        {
            _cardPaymentdDal.Update(cardPayment);
            return new SuccessResult(Messages.CardPaymentsUpdated);
        }

        private IResult CheckCreditCardNumber(string creditCardNumber)
        {
            var result = _cardPaymentdDal.Get(c => c.CreditCardNumber == creditCardNumber);

            if (result != null)
            {
                return new ErrorResult(Messages.CreditCardNumberAllreadyExists);
            }
            return new SuccessResult();
        }
    }
}
