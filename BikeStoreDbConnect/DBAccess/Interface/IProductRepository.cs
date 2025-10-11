using BikeStoreDbConnect.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.DBAccess.Interface
{
    internal interface IProductRepository
    {
        public Product GetByID(int Id); //Prende Un prodotto per id

        public List<Product> GetAllProducts();  //Prende tutti i valori di prodotto

    }
}