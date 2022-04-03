using System;
using Business.Concrete;
using Castle.Core.Configuration;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            
        }

        private static void DTOTest()
        {
            AirplaneMeneger airplaneMeneger = new AirplaneMeneger(new EfAirplaneDal(),new CategoryMeneger(new EfCategoryDal()));

            foreach (var airplane in airplaneMeneger.GetAirplaneDetail().Data)
            {
                Console.WriteLine(airplane.AirplaneName + " : " + airplane.CategoryName);
            }
        }

       

        private static void airplaneTest()
        {
            AirplaneMeneger airplaneMeneger = new AirplaneMeneger(new EfAirplaneDal(), new CategoryMeneger(new EfCategoryDal()));

            foreach (var airplane in airplaneMeneger.GetAllByCategoryId(0).Data)
            {
                Console.WriteLine(airplane.AirplaneName);
            }
        }
    }
}
