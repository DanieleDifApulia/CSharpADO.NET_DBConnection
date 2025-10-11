
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.Model
{
    internal class Product 
    {
      public int     Id {  get; set; }
      public string  Model { get; set; }
      public int  BrandId { get; set; }
      public int     CategoryId { get; set; }
      public int     ModelYear { get ; set; }
      public decimal Price { get; set; }    


    }
}
