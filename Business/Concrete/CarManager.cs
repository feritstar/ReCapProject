using Business.Abstract;
using Business.Constans;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if ((car.Description.Length > 1) && (car.DailyPrice > 0))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {                
                return new ErrorResult(Messages.CarInvalidName + "and" + Messages.CarInvalidDailyPrice);
            }                
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.BrandId == id));
        }

        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == id));
        }
    }
}
