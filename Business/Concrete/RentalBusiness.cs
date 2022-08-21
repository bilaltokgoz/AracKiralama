using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalBusiness : IRentalBusiness
    {
        IRentalDal rentalDal;
        public RentalBusiness(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IDataResult<Rental> Get(int id)
        {
            Rental rental = rentalDal.Get(r => r.Id == id);

            try
            {
             
                SuccessDataResult<Rental> successDataResult = new SuccessDataResult<Rental>(rental);
                return successDataResult;
            }
            catch (Exception ex)
            {
                ErrorDataResult<Rental> errorDataResult = new ErrorDataResult<Rental>(ex.Message);
              return errorDataResult;
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            List<Rental> rentals = rentalDal.GetAll();
            try
            {
              
                SuccessDataResult<List<Rental>>successDataResult=new SuccessDataResult<List<Rental>>(rentals);
                return successDataResult;
            }
            catch (Exception ex)
            {

                ErrorDataResult<List<Rental>> errorDataResult = new ErrorDataResult<List<Rental>>(ex.Message);
                return errorDataResult;
            }
        }
        public IResult Add(Rental rental)
        {
        
            try
            {
                if (rental.ReturnDate != null) 

                {
                    rentalDal.Add(rental);
                    SuccessResult successResult = new SuccessResult(true,"arac eklendi");
                  return successResult;
                }
                else
                {
                    ErrorResult errorResult = new ErrorResult(false, "eklenemedi");
                    return errorResult;
                }


            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public IResult Delete(Rental rental)
        {
            rentalDal.Delete(rental);

            try
            {
                
                SuccessResult successResult = new SuccessResult(true, "arac kaldırıldı");
                return successResult;
            }
            catch (Exception ex)
            {

                ErrorResult errorResult = new ErrorResult(false,ex.Message);
                return errorResult;
            }
        }

      

        public IResult Update(Rental rental)
        {
        rentalDal.Update(rental);
           
            try
            {
                SuccessResult successResult = new SuccessResult(true, "güncellendi");
                return successResult;
            }
            catch (Exception ex)
            {

               ErrorResult errorResult=new ErrorResult(false,ex.Message);
                return errorResult;
            }
        }
    }
}
