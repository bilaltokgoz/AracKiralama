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
  public class ColorBusiness:IColorBusiness
    {
        private readonly IColorDal colorDal;
        public ColorBusiness(IColorDal colorDal)
        {
         this.colorDal = colorDal;
        }
        public IDataResult<Color> Get(int id)
        {
            try
            {
                Color color = colorDal.Get(c => c.ColorId == id);
                SuccessDataResult<Color>successDataResult = new SuccessDataResult<Color>(color);
                return successDataResult;
            }
            catch (Exception ex)
            {

               return new ErrorDataResult<Color>(ex.Message);
            }
        }

        public IDataResult<List<Color>> GetList()
        {
            try
            {
                List<Color> colors = colorDal.GetAll();
                SuccessDataResult<List<Color>> successDataResult = new SuccessDataResult<List<Color>>(colors);
                return successDataResult;
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Color>>(ex.Message);
            }
       
        }

        public IResult Add(Color color)
        {
           
            try
            {
                colorDal.Add(color);
                SuccessResult successResult = new SuccessResult(true);
                return successResult;
            }
            catch (Exception)
            {

                return new ErrorResult(false);
            }
        }

        public IResult Delete(Color color)
        {
            try
            {
                colorDal.Delete(color);
                SuccessResult successResult = new SuccessResult(true);
                return successResult ;
            }
            catch (Exception)
            {

                return new ErrorResult(false);
            }
        }

       
    }
}
