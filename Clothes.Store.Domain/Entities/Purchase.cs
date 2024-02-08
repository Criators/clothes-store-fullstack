using Clothes.Store.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Entities
{
    public class Purchase
    {
        public Purchase()
        {
            Custumer = new Custumer();
            Address = new Address();
        }

        public Guid PurchaseID { get; set; }

        public Custumer Custumer { get; set; }

        public Address Address { get; set; }

        public Payment? Payment { get; set; }

        public PurchaseStatus? PurchaseStatus { get; set; }

        public decimal Freight { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CriationDateHour { get; set; }
    }
}
