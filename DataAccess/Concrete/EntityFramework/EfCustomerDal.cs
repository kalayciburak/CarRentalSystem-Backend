using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,CarRentalContext>,ICustomerDal {
        public List<CustomerDetailDto> GetCustomerDetails() {
            using var context = new CarRentalContext();
            var result = from cus in context.Customers
                join user in context.Users on cus.UserId equals user.UserId
                select new CustomerDetailDto {
                    CustomerId = cus.CustomerId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CompanyName = cus.CompanyName
                };
            return result.ToList();
        }
    }
}