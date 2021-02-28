using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalServices
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetCarsByBrandId(int id);
        IDataResult<List<Rental>> GetCarsByColorId(int id);
        IResult Add(Rental rental);
        
    }
}
