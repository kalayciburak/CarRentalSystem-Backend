using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework {
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalContext>, IColorDal {
    }
}