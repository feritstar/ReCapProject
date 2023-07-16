using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
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

            //GetCarDetailsTest();

            customerManager.Add(
                new Customer 
                {
                    CompanyName = "Sixt Rent A Car",
                    Id = 12
                });
            userManager.Add(
                new User
                {
                    Id = 12,                    
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "johndoe@something.com",
                    Password = "12345"
                });
            userManager.Add(
                new User
                {
                    Id = 13,
                    FirstName = "John2",
                    LastName = "Doe2",
                    EmailAddress = "john2doe2@something.com",
                    Password = "1234567"
                });
            rentalManager.Add(
                new Rental
                {
                    CarId = 1,
                    CustomerId = 1,
                    RentDate = DateTime.Now.AddDays(1),
                    ReturnDate = DateTime.Now.AddDays(15),
                });
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
