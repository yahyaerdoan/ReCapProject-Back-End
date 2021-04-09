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
    public class CardManager : ICardService
    {
        private readonly ICardDal _CarddDal;

        public CardManager(ICardDal CarddDal)
        {
            _CarddDal = CarddDal;
        }


        [ValidationAspect(typeof(CardValidator))]
        public IResult Add(Card Card)
        {
            IResult result = BusinessRules.Run(CheckCreditCardNumber(Card.CreditCardNumber));
            if (result != null)
            {
                return result;
            }            

            _CarddDal.Add(Card);
            return new SuccessResult(Messages.CardsAdded);
        }

        public IResult Delete(Card Card)
        {
            _CarddDal.Delete(Card);
            return new SuccessResult(Messages.CardsDeleted);
        }

        public IDataResult<List<Card>> GetAll()
        {            
            return new SuccessDataResult<List<Card>>(_CarddDal.GetAll(),Messages.CardsListed);
        }

        public IDataResult<Card> GetCardsByCustomerId(int customerId)
        {
            return new SuccessDataResult<Card>(_CarddDal.Get(c => c.CustomerId == customerId),Messages.GetCardPaymetsByCustomerIdListed);
        }

        public IResult Update(Card Card)
        {
            _CarddDal.Update(Card);
            return new SuccessResult(Messages.CardsUpdated);
        }

        private IResult CheckCreditCardNumber(string creditCardNumber)
        {
            var result = _CarddDal.Get(c => c.CreditCardNumber == creditCardNumber);

            if (result != null)
            {
                return new ErrorResult(Messages.CreditCardNumberAllreadyExists);
            }
            return new SuccessResult();
        }
    }
}
