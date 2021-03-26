using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface ICardPaymentService
    {
        IDataResult<List<CardPayment>> GetAll();
        IDataResult<CardPayment> GetCardPaymetsByCustomerId(int customerId);
        IResult Add(CardPayment cardPayment);
        IResult Update(CardPayment cardPayment);
        IResult Delete(CardPayment cardPayment);
    }
}
