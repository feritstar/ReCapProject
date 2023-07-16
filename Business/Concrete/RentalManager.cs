using Business.Abstract;
using Business.Constans;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if ((rental.RentDate != null) || (rental.ReturnDate != null))
            {
                return new ErrorResult(Messages.RentalReturnDateNull);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            var query = _rentalDal.Get(r => r.Id == rental.Id);
            _rentalDal.Delete(query);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByCustomerId(int customerId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CustomerId == customerId), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            var query = _rentalDal.Get(r => r.Id == rental.Id);
            query.CarId = rental.CarId;
            query.CustomerId = rental.CustomerId;
            query.RentDate = rental.RentDate;
            query.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(query);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
