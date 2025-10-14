using BikeStoreDbConnect.DBAccess.Service;
using BikeStoreDbConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.DBAccess.Interface
{
    public interface IProduct_OrderItem_Orders_Repository
    {
        public List<Product_OrderItems_Orders> GetOrdiniProdotti(int  status ); 

    }
}
