using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserServices
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetCarsByBrandId(int id);
        IDataResult<List<User>> GetCarsByColorId(int id);
        IResult Add(User user);
        
    }
}
