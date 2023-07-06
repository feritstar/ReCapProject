using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2023, DailyPrice = 1000, Description = "Otomatik Hatasız"},
                new Car{Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2020, DailyPrice = 2000, Description = "Manuel Hatasız"},
                new Car{Id = 3, BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 3000, Description = "Otomatik 1 Parça Boyalı"},
                new Car{Id = 4, BrandId = 3, ColorId = 1, ModelYear = 2022, DailyPrice = 4000, Description = "Otomatik Hatasız"},
                new Car{Id = 5, BrandId = 4, ColorId = 1, ModelYear = 2019, DailyPrice = 1000, Description = "Otomatik Hatasız"},
                new Car{Id = 6, BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 1500, Description = "Otomatik Hatasız"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<Car> GetByModelYear(int modelYear)
        {
            return _cars.Where(c => c.ModelYear == modelYear).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
