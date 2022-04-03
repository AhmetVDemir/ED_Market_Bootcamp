using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryAirplaneDal : IAirplaneDal
    {
        //global değişkenler _ ile tanımlanır yazım standartı
        List<Airplane> _airplanes;

        public InMemoryAirplaneDal()
        {
            _airplanes = new List<Airplane>() {

                new Airplane{AirplaneId =0,CategoryId =1, AirplaneBrand="Airbus",AirplaneModel="A380",AirplaneName="Airbus A380",UnitPrice=20000,UnitsInStock="3"},
                new Airplane{AirplaneId =1,CategoryId =1, AirplaneBrand="Airbus",AirplaneModel="A320",AirplaneName="Airbus A320",UnitPrice=10000,UnitsInStock="5"},
                new Airplane{AirplaneId =2,CategoryId =1, AirplaneBrand="Boing",AirplaneModel="777-200",AirplaneName="Boing 777",UnitPrice=50000,UnitsInStock="4"},
                new Airplane{AirplaneId =3,CategoryId =2, AirplaneBrand="Tusaş",AirplaneModel="129",AirplaneName="Atak 129",UnitPrice=5000,UnitsInStock="7"},
                new Airplane{AirplaneId =4,CategoryId =2, AirplaneBrand="Roninson",AirplaneModel="AR44II",AirplaneName="AR44 RAVEN",UnitPrice=20000,UnitsInStock="10"}

            };
        }

        public void Add(Airplane airplane)
        {
            _airplanes.Add(airplane);
            Console.WriteLine(airplane.AirplaneName + " başarıyla eklendi !");
        }

        public void Delete(Airplane airplane)
        {

            // _airplanes.Remove(airplane); bu kod ürünü silmez çünkü referans numarasını göndermiyoruz

            /*
             * referansını yakala ve sil
             * 
            Airplane airplanetodelete = null;
            foreach (var a in _airplanes)
            {
                 if(airplane.AirplaneId == a.AirplaneId)
                {
                    airplanetodelete = a;
                }
            }
            */

            Airplane airplaneForDelete = _airplanes.SingleOrDefault(a => a.AirplaneId == airplane.AirplaneId); //Linq ile
            _airplanes.Remove(airplaneForDelete);

            Console.WriteLine("Silindi");
        }

        public Airplane Get(Expression<Func<Airplane, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<AirplaneDetailDto> GetAirplaneDetail()
        {
            throw new NotImplementedException();
        }

        public List<Airplane> GetAll()
        {
            return _airplanes;
        }

        public List<Airplane> GetAll(Expression<Func<Airplane, bool>> filter = null)
        {
            return _airplanes.ToList();
        }

        public List<Airplane> GetAllByCategory(int catId)
        {
            return _airplanes.Where(a => a.CategoryId == catId).ToList(); 
        }

        public void Update(Airplane airplane)
        {
            Airplane airplaneForUpdate = _airplanes.SingleOrDefault(a => a.AirplaneId == airplane.AirplaneId);
            airplaneForUpdate.AirplaneName = airplane.AirplaneName;
            airplaneForUpdate.AirplaneBrand = airplane.AirplaneBrand;
            airplaneForUpdate.AirplaneModel = airplane.AirplaneModel;
            airplaneForUpdate.CategoryId = airplane.CategoryId;
            airplaneForUpdate.UnitPrice = airplane.UnitPrice;
            airplaneForUpdate.UnitsInStock = airplane.UnitsInStock;

        }

        
    }
}
