using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.Model
{
    public class Product_OrderItems_Orders
    {
                //Model di product
        public string Model { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ModelYear { get; set; }
        public decimal Price { get; set; }

             // Model di Order Items
        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        //Model di Orders
        public int CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int StoreId { get; set; }

        public int StaffId { get; set; }

        public override string ToString()
        {
            return  "--------------------------" +
                    "\nOrderId : " + OrderId +
                   "\nItemId : " + ItemId +
                   "\nProductId : " + ProductId +
                   "\nQuantity : " + Quantity +
                   "\nPrice : " + Price +
                   "\nDiscount : " + Discount +
                   "\nModel :" + Model +
                   "\nCategoty  :" + CategoryId +
                   "\nModel Year  :" + ModelYear +
                   "\nOrder Status : " + OrderStatus +
                   "\nOrder Date : " + OrderDate +
                   "\nRequired Date : " + RequiredDate +
                   "\nShippedDate : " + ShippedDate +
                   "\nStore Id : " + StoreId +
                   "\nStaff Id : " + StaffId +
                   "\n-----------------------------";
        }





    }
}
