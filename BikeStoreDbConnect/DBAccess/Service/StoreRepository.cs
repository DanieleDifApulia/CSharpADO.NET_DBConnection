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
    internal class StoreRepository : IStoreRepository
    {

        public Store GetByID(int Id)
        {
            Store store = new Store(); //Oggetto che conterra i dati finali del database
                                             //Assegnazione della stringa della connessione
            var connectionString = Config.Config.BikeStoreConnectString;
           //Creazione Connessione
           var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open(); //Apertura della Connessione
                    //Stringa Query del comando da eseguire sul DB

                String query = "SELECT  *  FROM [sales].stores s WHERE s.store_id = @Store_id;"; //Aggiunta del parametro
                var paramId = new SqlParameter //Creazione del parameter
                {
                    ParameterName = "@Store_id",  //Nota nel libro richiede ; nova versione richiede ,
                    DbType = DbType.Int32,
                    Value = Id
                };
                var comQuery= new SqlCommand(query , conn); //Creazione del comando db 
                comQuery.Parameters.Add(paramId);
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comando
                while (reader.Read())
                {
                    store.StoreId = reader.GetInt32(0);
                    store.StoreName = reader.GetString(1);
                    store.Phone = reader.GetString(2);
                    store.Email = reader.GetString(3);
                    store.Street = reader.GetString(4);
                    store.City = reader.GetString(5);
                    store.State = reader.GetString(6);
                    store.ZipCode = reader.GetString(7);

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



            return store ;
        }


        public List<Store> GetAllStores() {
            List<Store> resultStores = new List<Store>(); //Lista risultato della query 


            var connectionString = Config.Config.BikeStoreConnectString; //Assegnazione stringa di connessione
            //Creazione Connessione
            var conn = new SqlConnection(connectionString); //Creazione dell'istanza della connessione
            try
            {
                Console.WriteLine("Apertura della connessione al db..");
                conn.Open(); //Apertura della Connessione
                            
                //Stringa Query del comando da eseguire sul DB
                String query = "SELECT * FROM [sales].stores;"; //Select all
                var comQuery = new SqlCommand(query, conn);  //Creazione del comando db 
                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comandoSQL
                while (reader.Read()) //Legge ogni riga della query 
                {
                    Store store = new Store(); //LA dichiarazione va inserita qua dentro dichiarata fuori inizializza la lista sempre con gli stessi valori
                    store.StoreId = reader.GetInt32(0);
                    store.StoreName = reader.GetString(1);
                    store.Phone = reader.GetString(2) ;
                    store.Email = reader.GetString(3);
                    store.Street = reader.GetString(4);
                    store.City = reader.GetString(5);
                    store.State = reader.GetString(6);
                    store.ZipCode = reader.GetString(7);
                    resultStores.Add(store); //Aggiunge il negozio che ha letto dalla riga della query
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



            return resultStores;
        }
    }
}
