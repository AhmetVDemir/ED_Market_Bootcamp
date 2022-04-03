using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAirplaneService
    {
        IDataResult<List<Airplane>> GetAll();

        IDataResult<List<Airplane>> GetAllByCategoryId(int id);

        IDataResult<List<Airplane>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<AirplaneDetailDto>> GetAirplaneDetail(); 

       IDataResult<Airplane> GetById(int Id);

       IResult AddAirplane(Airplane airplane);

       IResult UpdateAirplane(Airplane airplane);

        IResult AddTransactionTest(Airplane airplane);
      
    }
}
