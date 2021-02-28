using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IColorServices
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Uptade(Color color);
        IResult Delete(Color color);

    }
}
