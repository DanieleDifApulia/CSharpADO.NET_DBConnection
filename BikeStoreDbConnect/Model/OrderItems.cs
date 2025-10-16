using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.Model
{
    internal class OrderItems
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public  int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }

        public override string ToString()
        {
            return "OrderId : " + OrderId + "ItemId : " + ItemId + "Quantity : " + Quantity + "List Price : " + ListPrice + "Discount" + Discount;
        }
    }
}



