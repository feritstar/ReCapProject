using System;
using System.Collections.Generic;
using System.Text;
using Core.Results;
using Entities.Concrete;
using Entities.DTOS;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarsByBrandId(int id);
        IDataResult<Car> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
    }
}
