using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "BMW-Kırmızı",
                    ModelYear = Convert.ToInt16(DateTime.Now.Year)
                },
                new Car
                {
                    CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 200, Description = "BMW-Siyah",
                    ModelYear = Convert.ToInt16(DateTime.Now.Year)
                },
                new Car
                {
                    CarId = 3, BrandId = 2, ColorId = 1, DailyPrice = 250, Description = "Mercedes-Kırmızı",
                    ModelYear = Convert.ToInt16(DateTime.Now.Year)
                }

            };
        }


        public Car GetById(int id)
        {
            return _cars.Find(s => s.CarId == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var tempCar = _cars.SingleOrDefault(s =>s.CarId == car.CarId);
            _cars.Remove(tempCar);
        }

        public void Update(Car car)
        {
            var tempCar = _cars.SingleOrDefault(s => s.CarId == car.CarId);
            tempCar.ColorId = car.ColorId;
            tempCar.BrandId = tempCar.ColorId;
            tempCar.DailyPrice = car.DailyPrice;
            tempCar.Description = car.Description;
            tempCar.ModelYear = car.ModelYear;
        }

        public List<CarDetailDto> getCarDetailDto()
        {
            throw new NotImplementedException();
        }
    }
}
