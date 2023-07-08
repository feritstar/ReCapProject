using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyCarsContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (MyCarsContext context = new MyCarsContext())
            {
                var query = from c in context.Cars
                            join b in context.Brands on c.BrandId equals b.BrandId
                            join cl in context.Colors on c.ColorId equals cl.ColorId
                            select new CarDetailsDto
                            {
                                CarId = c.Id,
                                BrandName = b.BrandName,
                                ColorName = cl.ColorName,
                                ModelYear = c.ModelYear,
                                DailyPrice = c.DailyPrice,
                                Description = c.Description
                            };
                return query.ToList();
            }
        }
    }
}
