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

            var carQuery = carManager.GetCarDetails();

            if (carQuery.Success)
            {
                foreach (var car in carQuery.Data)
                {
                    Console.WriteLine(car.CarId + ", " +
                                      car.BrandName + ", " +
                                      car.ColorName + ", " +
                                      car.ModelYear + ", " +
                                      car.DailyPrice + ", " +
                                      car.Description + "\n");
                }
            }
            else
            {
                Console.WriteLine(carQuery.Message);
            }

            Console.WriteLine("************************************************\n");

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var brandQuery = brandManager.GetAll();
            if (brandQuery.Success)
            {
                foreach (var brand in brandQuery.Data)
                {
                    Console.WriteLine(brand.BrandName + "\n");
                }
            }
            else
            {
                Console.WriteLine(brandQuery.Message);
            }

            Console.WriteLine("************************************************\n");

            ColorManager colorManager = new ColorManager(new EfColorDal());

            var colorQuery = colorManager.GetAll();
            if (colorQuery.Success)
            {
                foreach (var color in colorQuery.Data)
                {
                    Console.WriteLine(color.ColorName + "\n");
                }                        
            }
            else
            {
                Console.WriteLine(colorQuery.Message);
            }
        }
    }
}
