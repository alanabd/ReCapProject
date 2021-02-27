using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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

        public void Add(Car car)
        {
            
            if (car.Description.Length<=2||car.DailyPrice<=0)
            {
                Console.WriteLine("Araç açıklması 2 karakterden fazla olmalıdır");
                Console.WriteLine("Araç kiralama bedeli 0 dan büyük olmalı");
            }
            else
            {
                _carDal.Add(car);
            }
            
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> getCarDetails()
        {
            return _carDal.getCarDetailDto();
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
