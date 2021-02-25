using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarServices
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll(s => s.BrandId == id);
            return result;
        }

        public List<Car> GetCarsByColorId(int id)
        {
            var result = _carDal.GetAll(s => s.ColorId == id);
            return result;
        }
    }
}
