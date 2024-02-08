using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Entities
{
    public class ShoppingProduct
    {
        public ShoppingProduct()
        {
            Product = new Product();
        }

        public Product Product { get; set; }

        public Guid PurchaseID { get; set; }
    }
}
