using Core.Concrete;
using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfColorDal : EfRepository<Color, EfContext>, IColorDal
    {
     
    }
}
