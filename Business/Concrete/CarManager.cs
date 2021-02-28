using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarServices
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.PrductAdded);
            
            
        }
        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour > 8&&DateTime.Now.Hour<22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<CarDetailDto>> getCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.getCarDetailDto(), "ürünler listelendi");
        }

        
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(s => s.BrandId == id));
        }

        
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(s => s.ColorId == id));
        }
    }
}
