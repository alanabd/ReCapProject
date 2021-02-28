using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandServices
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetCarsByBrandId(int id);
        IDataResult<List<Brand>> GetCarsByColorId(int id);
        IResult Add(Brand brand);
        
    }
}
