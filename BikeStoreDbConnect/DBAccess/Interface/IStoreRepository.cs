using BikeStoreDbConnect.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.DBAccess.Interface
{
    internal interface IStoreRepository
    {
        public Store GetByID(int Id); //Prende Un negozio per id

        public List<Store> GetAllStores();  //Prende tutti i valori di negozio

    }
}