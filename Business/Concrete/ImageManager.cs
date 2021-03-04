using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ImageManager : IImageServices
    {
        private IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(CarImage carImage)
        {
            BusinessRules.Run(CheckCarImagesCount(carImage.CarId));
            _imageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _imageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetCarsById(int id)
        {
            var result = _imageDal.GetAll(s => s.CarId == id);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        private IResult CheckCarImagesCount(int id)
        {
            var result = _imageDal.GetAll(s => s.CarId == id);
            if (result.Count>5)
            {
                return new ErrorResult(Messages.CarImagesCount);
            }

            return new SuccessResult();
        }
    }
}
