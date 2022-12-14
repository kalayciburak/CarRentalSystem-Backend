using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Abstract {
    public interface ICustomerDal : IEntityRepository<Customer> {
        List<CustomerDetailDto> GetCustomerDetails();
    }
}