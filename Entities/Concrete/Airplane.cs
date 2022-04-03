
using Core.Entities;

namespace Entities.Concrete
{
    public class Airplane: IEntity
    {
        public int AirplaneId { get; set; }

        public int CategoryId { get; set; }

        public string AirplaneName { get; set; }

        public string AirplaneBrand { get; set; }

        public string AirplaneModel { get; set; }

        public string UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

    }
}
