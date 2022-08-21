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
  public class BrandBusiness:IBrandBusiness
    {
        private readonly IBrandDal brandDal;
        public BrandBusiness(IBrandDal brandDal)
        {
         this.brandDal = brandDal;
        }
        public IDataResult<Brand> Get(int id)
        {
         
            try
            {
                Brand brand = brandDal.Get(b => b.BrandId == id);
                SuccessDataResult<Brand> successDataResult = new SuccessDataResult<Brand>(brand);
                return successDataResult;
            }
            catch (Exception ex)
            {

               return new ErrorDataResult<Brand>(ex.Message);
            }
        }

        public IDataResult<Brand> Get(string name)
        {
            try
            {
                Brand brand=brandDal.Get(b=>b.BrandName==name);
                SuccessDataResult<Brand>successDataResult= new SuccessDataResult<Brand>(brand);
                return successDataResult;
            }
            catch (Exception ex)
            {

               return new ErrorDataResult<Brand>(ex.Message);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                List<Brand> brands = brandDal.GetAll();
                SuccessDataResult<List<Brand>>successDataResult= new SuccessDataResult<List<Brand>>(brands);
                return successDataResult;

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Brand>>(ex.Message);
            }
        }

        public IResult Add(Brand brand)
        {
         
            try
            {
                brandDal.Add(brand);
                SuccessResult successResult = new SuccessResult(true);
                return successResult;

            }
            catch (Exception ex)
            {

            return new ErrorDataResult<List<Brand>>(ex.Message);
            }
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                brandDal.Delete(brand);
                SuccessResult successResult= new SuccessResult(true);
                return successResult;
            }
            catch ( Exception)
            {

                return new ErrorResult(false);
            }
        }

        
    }
}
