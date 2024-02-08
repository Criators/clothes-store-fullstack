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
    public class Product
    {
        public Guid ProductID { get; set; }

        public string Title { get; set; }

        public TypeOfProduct? Type { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public DateTime CriationDateHour { get; set; }

        public BigInteger Stock { get; set; }
    }
}
