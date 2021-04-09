using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> GetCardsByCustomerId(int customerId);
        IResult Add(Card Card);
        IResult Update(Card Card);
        IResult Delete(Card Card);
    }
}
