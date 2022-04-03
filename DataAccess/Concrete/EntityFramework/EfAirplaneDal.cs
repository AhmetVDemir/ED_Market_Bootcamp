using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    //airplanedal interface i db nesnesine özel operasyonlar için var (List<AirplaneDetailDto> IAirplaneDal a özgğ opersayonn  )
    public class EfAirplaneDal : EfEntityRepostoryBase<Airplane, MarketContext>, IAirplaneDal
    {
        public List<AirplaneDetailDto> GetAirplaneDetail()
        {
            using(MarketContext mc = new MarketContext())
            {
                var result = from a in mc.Airplanes
                             join c in mc.Categories on a.CategoryId equals c.CategoryId
                             select new AirplaneDetailDto {
                                 AirplaneId = a.AirplaneId,
                                 AirplaneName = a.AirplaneName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = a.UnitsInStock
                             
                             };

                return result.ToList();

            }
        }
    }
} 
