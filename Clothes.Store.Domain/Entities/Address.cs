using Clothes.Store.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Clothes.Store.Domain.Entities
{
    public class Address
    {
        public Address() {
            Custumer = new Custumer();   
        }

        public Guid AddressID { get; set; }

        public Custumer Custumer { get; set; }

        public string Country { get; set; }

        public string CEP { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public BigInteger Number { get; set; }

        public DateTime CriationDateHour { get; set; }
    }
}
