﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOS;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

        List<CarDetailsDto> GetCarDetails();
    }
}
