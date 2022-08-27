using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Abstract {
    public interface ICustomerService {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}