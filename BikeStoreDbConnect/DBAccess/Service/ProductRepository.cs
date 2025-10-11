using BikeStoreDbConnect.Config;
using BikeStoreDbConnect.DBAccess.Interface;
using BikeStoreDbConnect.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.DBAccess.Service
{
    internal class ProductRepository : IProductRepository
    {

        public Product GetByID()
        {
            Product product = new Product(); //Oggetto che conterra i dati finali del database
                                             //Assegnazione della stringa della connessione
            var connectionString = Config.Config.BikeStoreConnectString;
           //Creazione Connessione
           var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open(); //Apertura della Connessione
                    //Stringa Query del comando da eseguire sul DB
                String query = "SELECT  *  FROM [production].products p WHERE p.product_id = 1;";
                var comQuery= new SqlCommand(query); //Creazione del comando db 
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comando
                while (reader.Read()) {
                    product.Id = reader.GetInt32(0);
                    product.Model = reader.GetString(1);
                    product.BrandId = reader.GetInt32(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ModelYear = reader.GetInt32(4);
                    product.Price = reader.GetDecimal(5);
                }
            }
            catch (SqlException ex)
            {
                // Gestione dell'eccezione
                Console.WriteLine("ERRORE NELL CONNESSIONE");
                Console.WriteLine(ex.Message);
 
            }
            finally
            {
                // Chiusura della connessione
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }



            return product ;
        }

    }
}
