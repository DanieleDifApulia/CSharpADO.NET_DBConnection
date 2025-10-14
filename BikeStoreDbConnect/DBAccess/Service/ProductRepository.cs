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

        public Product GetByID(int Id)
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

                String query = "SELECT  *  FROM [production].products p WHERE p.product_id = @product_id;"; //Aggiunta del parametro
                var paramId = new SqlParameter //Creazione del parameter
                {
                    ParameterName = "@product_id",  //Nota nel libro richiede ; nova versione richiede ,
                    DbType = DbType.Int32,
                    Value = Id
                };
                var comQuery= new SqlCommand(query , conn); //Creazione del comando db 
                comQuery.Parameters.Add(paramId);
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comando
                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                    product.Model = reader.GetString(1);
                    product.BrandId = reader.GetInt32(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ModelYear = reader.GetInt16(4);
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


     

        public List<Product> GetAllProducts() {
            List<Product> resultProducts = new List<Product>(); //Lista risultato della query 


            var connectionString = Config.Config.BikeStoreConnectString; //Assegnazione stringa di connessione
            //Creazione Connessione
            var conn = new SqlConnection(connectionString); //Creazione dell'istanza della connessione
            try
            {
                Console.WriteLine("Apertura della connessione al db..");
                conn.Open(); //Apertura della Connessione
                            
                //Stringa Query del comando da eseguire sul DB
                String query = "SELECT * FROM [production].products;"; //Select all
                var comQuery = new SqlCommand(query, conn);  //Creazione del comando db 
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comandoSQL
                while (reader.Read()) //Legge ogni riga della query 
                {
                    Product product = new Product(); //LA dichiarazione va inserita qua dentro dichiarata fuori inizializza la lista sempre con gli stessi valori
                    product.Id = reader.GetInt32(0);
                    product.Model = reader.GetString(1);
                    product.BrandId = reader.GetInt32(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ModelYear = reader.GetInt16(4);
                    product.Price = reader.GetDecimal(5); 
                    resultProducts.Add(product); //Aggiunge il prodtto che ha letto dalla riga della query
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
                Console.WriteLine("Chiusura della connessione al db..");
                // Chiusura della connessione
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }



            return resultProducts;
        }


        public int CountProducts() {
            int productsCount = 0;
            var connectionString = Config.Config.BikeStoreConnectString;
            //Creazione Connessione
            var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open(); //Apertura della Connessione
                             //Stringa Query del comando da eseguire sul DB

                String query = "SELECT COUNT(*) FROM production.products;;"; //Aggiunta del parametro

                var comQuery = new SqlCommand(query, conn); //Creazione del comando db 
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comando
                while (reader.Read())
                {
                    productsCount =  reader.GetInt32(0);
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
            return productsCount;
        }


        public bool Update(Product product)  //Da implementare 
        {
            return false;
        }
        public bool Delete(Product product) //Da Implementare
        {
            return false;
        }

        public bool Insert(Product product) { //Da Implementare
            return false;
        }
    }
}
