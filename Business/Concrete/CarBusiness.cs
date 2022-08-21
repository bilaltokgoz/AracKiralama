using Business.Absrtact;
using Business.Constants;
using Core.Utilities;
using DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class CarBusiness:ICarBusiness
    {
        private readonly ICarDal carDal;
        public CarBusiness(ICarDal carDal)
        {
         this.carDal = carDal;
        }


        public IDataResult< Car> Get(int id)
        {
            try
            {Car car= carDal.Get(c => c.CarId == id);
               SuccessDataResult<Car> successDataResult = new SuccessDataResult<Car>(data: car, message: "mmm");
                return successDataResult;
            }
            catch (Exception ex)
            {
                ErrorDataResult<Car> errorDataResult = new ErrorDataResult<Car>(ex.Message);

                return errorDataResult;
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                //List<Product> products = productDal.GetAll();
                SuccessDataResult<List<Car>> successDataResult = new SuccessDataResult<List<Car>>(carDal.GetAll(), Messages.CarListed);
                return successDataResult;

            }
            catch (Exception ex)
            {

              return new ErrorDataResult<List<Car>>(ex.Message);
            }
        }

        public IDataResult< List<Car>> GetAllByBrandId(int brandId)
        {
           
            try
            {
                SuccessDataResult<List<Car>> successDataResult = new SuccessDataResult<List<Car>>(carDal.GetAll(p => p.BrandId== brandId));
                return successDataResult;
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Car>>(ex.Message);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            try
            {
                SuccessDataResult<List<CarDetailDto>> successDataResult=new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetails());

                return successDataResult;
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
        }

        public IResult Add(Car car)
        {
            try
            {
                // Product product1 = new Product();

                // product1.ProductName = "ilk ürün";
                // product1.CategoryId = 1;
                // product1.Description = "Eklediğimiz ilk ürün";
                // product1.UnitsInStock = 1;

                //return=productDal.Add(product);
                carDal.Add(car);
                SuccessResult successResult = new SuccessResult(true, Messages.CarAdded);
               
                return successResult;
            }
            catch (Exception ex)
            {
          return new ErrorResult(false,ex.Message);
            }
        }
    }
}
