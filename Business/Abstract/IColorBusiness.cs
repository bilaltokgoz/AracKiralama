using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absrtact
{
   public interface IColorBusiness
    {
        IDataResult<Color> Get(int id);
        IDataResult<List<Color>> GetList();
        IResult Add(Color color);
        IResult Delete(Color color);
    }
}
