using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RecapContext>,ICarDal
    {
        public List<CarDetailDto> getCarDetailDto()
        {
            using (RecapContext context=new RecapContext())
            {
                var result = from p in context.Cars
                    join c in context.Colors
                        on p.ColorId equals c.ColorId
                        join b in context.Brands
                            on p.BrandId equals b.BrandId
                    select new CarDetailDto { CarId = p.CarId, Description = p.Description, ColorName = c.ColorName, BrandName = b.BrandName };
                return result.ToList();
            }
        }
    }
}
