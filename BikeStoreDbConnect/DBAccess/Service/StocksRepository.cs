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
    internal class StoksRepository 
    {
        public Stock GetByID(int Id)
        {
            Stock stock = new Stock();
            var connectionString = Config.Config.BikeStoreConnectString;
            //Creazione Connessione
            var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open(); //Apertura della Connessione
                             //Stringa Query del comando da eseguire sul DB
                //Oggetto che conterra i dati finali del database
                                           //Assegnazione della stringa della connessione

                String query = "SELECT  *  FROM production.stoks s WHERE s.store_id = @Store_id;"; //Aggiunta del parametro
                var paramId = new SqlParameter //Creazione del parameter
                {
                    ParameterName = "@Store_id",  //Nota nel libro richiede ; nova versione richiede ,
                    DbType = DbType.Int32,
                    Value = Id
                };
                var comQuery = new SqlCommand(query, conn); //Creazione del comando db 
                comQuery.Parameters.Add(paramId);
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comando
                while (reader.Read())
                {
                   stock.StoreId = reader.GetInt32(0);
                   stock.ProductId = reader.GetInt32(1);
                   stock.Quantity = reader.GetInt32(2);
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



            return stock;
        }

        public List<Stock> GetAllStocks()
        {
            List<Stock> resultStocks = new List<Stock>(); //Lista risultato della query 


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
                    Stock stock = new Stock(); //LA dichiarazione va inserita qua dentro dichiarata fuori inizializza la lista sempre con gli stessi valori
                    stock.Id = reader.GetInt32(0);
                    stock.Model = reader.GetString(1);
                    stock.BrandId = reader.GetInt32(2);
                    stock.CategoryId = reader.GetInt32(3);
                    stock.ModelYear = reader.GetInt16(4);
                    stock.Price = reader.GetDecimal(5);
                    resultStocks.Add(stock); //Aggiunge il stock che ha letto dalla riga della query
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
            return resultStocks;
        }

        public List<Stock> GetProductsByName(string productName)
        {
            List<Stock> resultProducts = new List<Stock>(); //Lista risultato della query 


            var connectionString = Config.Config.BikeStoreConnectString; //Assegnazione stringa di connessione
            //Creazione Connessione
            var conn = new SqlConnection(connectionString); //Creazione dell'istanza della connessione
            try
            {
                Console.WriteLine("Apertura della connessione al db..");
                conn.Open(); //Apertura della Connessione


                //Stringa Query del comando da eseguire sul DB
                String query = "SELECT * FROM  production.products p WHERE p.product_name LIKE @String "; //Select all

                var paramName = new SqlParameter //Creazione del parameter
                {
                    ParameterName = "@String",  //Nota nel libro richiede ; nova versione richiede ,
                    SqlDbType = SqlDbType.NVarChar,
                    Value = "%" + productName + "%"
                };


                var comQuery = new SqlCommand(query, conn);  //Creazione del comando db 
                comQuery.Parameters.Add(paramName);
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comandoSQL
                while (reader.Read()) //Legge ogni riga della query 
                {
                    Stock product = new Stock(); //LA dichiarazione va inserita qua dentro dichiarata fuori inizializza la lista sempre con gli stessi valori
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
    }
}
