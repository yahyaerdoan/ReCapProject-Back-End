using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IDataResult<User> GetByUser(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
