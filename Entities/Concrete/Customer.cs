
using Core.Entities;


namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string City { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }


    }
}
