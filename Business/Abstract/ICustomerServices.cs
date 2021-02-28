using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerServices
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCarsByBrandId(int id);
        IDataResult<List<Customer>> GetCarsByColorId(int id);
        IResult Add(Customer customer);
        
    }
}
