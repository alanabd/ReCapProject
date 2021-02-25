using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                CarId = 8,
                BrandId = 3,
                ColorId = 3,
                DailyPrice = 100,
                Description = "d",
                ModelYear = 2012
            });
            foreach (var item in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
