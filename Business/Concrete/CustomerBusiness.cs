using Business.Absrtact;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerDal customerDal;
        public CustomerBusiness(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;

        }
        public IDataResult<Customer> Get(int id)
        {
           
            try
            {
                Customer customer = customerDal.Get(c => c.UserID == id);
                SuccessDataResult<Customer>successDataResult = new SuccessDataResult<Customer>(customer);
                return successDataResult;
            }
            catch (Exception)
            {

                return new ErrorDataResult<Customer>();
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
              List<Customer>customers=customerDal.GetAll();
                SuccessDataResult<List<Customer>> successDataResult = new SuccessDataResult<List<Customer>>(customers);
                return successDataResult;

            }
            catch (Exception)
            {

              return new ErrorDataResult<List<Customer>>();
            }
        }
        public IResult Add(Customer customer)
        {
            try
            {
                customerDal.Add(customer);
                SuccessResult successResult = new SuccessResult(true);
                return successResult;
            }
            catch (Exception)
            {
                return new ErrorResult(false);
            }
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                customerDal.Delete(customer);
                SuccessResult successResult=new SuccessResult(true);
                return successResult;
            }
            catch (Exception)
            {

                return new ErrorResult(false);
            }
        }

      

        public IResult Update(Customer customer)
        {
            try
            {
                customerDal.Update(customer);
                SuccessResult successResult= new SuccessResult(true);
                return successResult;
            }
            catch (Exception)
            {

                return new ErrorResult(false);
            }

        }
    }
}
