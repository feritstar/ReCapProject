using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.ModelYear + " " + item.Description);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.Description);
            //}

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}

            GetCarDetailsTest();
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + ", " +
                                  car.BrandName + ", " +
                                  car.ColorName + ", " +
                                  car.ModelYear + ", " +
                                  car.DailyPrice + ", " +
                                  car.Description + "\n");
            }
        }
    }
}
