using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public Customer(int customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }
    }

}
