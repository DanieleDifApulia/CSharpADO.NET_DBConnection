using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.Model
{
    internal class Orders
    {
        public int OrderId { get; set;}
        public int CustomerId { get; set;}
        public int  OrderStatus { get; set;}
        public DateTime OrderDate { get; set;}

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set;}

        public int   StoreId { get; set;}

        public int StaffId { get; set; }

        public override string ToString()
        {
            return "[OrderId : " + OrderId +
                "CustomerId :  "+ CustomerId  +
                "OrderStatus :  "+ OrderStatus + 
                "Order Date :  " + OrderDate +
                "Required Date :  " + RequiredDate +
                "ShippedDate" + ShippedDate +
                "StoreId" + StoreId +
                "StaffId" + StaffId;
        }

    }
}
