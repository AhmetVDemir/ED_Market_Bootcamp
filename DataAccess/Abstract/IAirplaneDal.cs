using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    //Bu ürünle ilgili db de yapılacak operasyonlar
    public interface IAirplaneDal : IEntityRepository<Airplane>
    {
        List<AirplaneDetailDto> GetAirplaneDetail();
    }
}
