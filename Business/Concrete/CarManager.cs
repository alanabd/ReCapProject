using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (CheckIfCarCountOfCategoryCorrect(car.BrandId).Success)
            {
                if (ChecekCarName(car.Description).Success)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.Added);
                }

            }

            return new ErrorResult();



        }
        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<CarDetailDto>> getCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.getCarDetailDto(), Messages.ProductsListed);
        }


        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(s => s.BrandId == id));
        }


        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(s => s.ColorId == id));
        }
        private IResult CheckIfCarCountOfCategoryCorrect(int brandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            }

            return new SuccessResult();
        }
        private IResult ChecekCarName(string CarDescription)
        {
            var result = _carDal.GetAll(s => s.Description == CarDescription).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameInvalidAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
