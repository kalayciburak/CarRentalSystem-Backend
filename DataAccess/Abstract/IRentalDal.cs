using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Abstract {
    public interface IRentalDal : IEntityRepository<Rental> {
        List<RentalDetailsDto> GetRentalDetails();
    }
}