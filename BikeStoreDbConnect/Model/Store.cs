
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.Model
{
    internal class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City{ get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public override string ToString()
        {
            return "[StoreId : " + StoreId + " " +
                    "StoreName : " + StoreName + " | " +
                    "Phone : " + Phone + " | " +
                    "Email : " + Email + " | " +
                    "Street: " + Street + " | " +
                    "City : " + City + " |" +
                    "State: " + State + " | " +
                    "ZipCode: " + ZipCode + " ] ";
        }
    }
}
