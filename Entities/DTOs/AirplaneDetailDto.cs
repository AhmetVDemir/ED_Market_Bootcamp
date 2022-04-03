
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AirplaneDetailDto:IDto
    {
        public int AirplaneId { get; set; }

        public string AirplaneName { get; set; }

        public string CategoryName { get; set; }

        public string UnitsInStock { get; set; }


    }
}
