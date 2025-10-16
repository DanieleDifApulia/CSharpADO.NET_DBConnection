using BikeStoreDbConnect.DBAccess.Interface;
using BikeStoreDbConnect.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDbConnect.DBAccess.Service
{
    public class Product_OrderItem_Orders_Repository : IProduct_OrderItem_Orders_Repository
    {
        public List<Product_OrderItems_Orders> GetOrdiniProdotti(int status){
                //Lista dei prodooti 
            List<Product_OrderItems_Orders> list = new List<Product_OrderItems_Orders>();
            var connectionString = Config.Config.BikeStoreConnectString; //Assegnazione stringa di connessione
            //Creazione Connessione
            var conn = new SqlConnection(connectionString); //Creazione dell'istanza della connessione
            try
            {
                Console.WriteLine("Apertura della connessione al db..");
                conn.Open(); //Apertura della Connessione


                var paramStatus = new SqlParameter //Creazione del parameter
                {
                    ParameterName = "@status",  //Nota nel libro richiede ; nova versione richiede ,
                    DbType = DbType.Int32,
                    Value = status
                };

                //Stringa Query del comando da eseguire sul DB
                String query = "SELECT * FROM sales.order_items oi join production.products  p on oi.product_id = p.product_id join sales.orders o on o.order_id = oi.order_id where o.order_status  = @status"; //Select all
                var comQuery = new SqlCommand(query, conn);  //Creazione del comando db 
                                                             //Aggiunta del parametro in input per status
                comQuery.Parameters.Add(paramStatus);

                SqlDataReader reader = comQuery.ExecuteReader(); //Creazione dell'istanza che leggerà l'output del comandoSQL

                while (reader.Read()) //Legge ogni riga della query 
                {
                        //Creazione di una nuova istanza per i dati della riga 
                    Product_OrderItems_Orders row = new Product_OrderItems_Orders(); //Riga della join
                    row.OrderId = reader.GetInt32(0); //
                    row.ItemId = reader.GetInt32(1); //
                    row.ProductId = reader.GetInt32(2); //
                    row.Quantity = reader.GetInt32(3); //
                    row.Price = reader.GetDecimal(4); //
                    row.Discount = reader.GetDecimal(5); //
                    row.Model = reader.GetString(7); //
                    row.BrandId = reader.GetInt32(8); //
                    row.CategoryId = reader.GetInt32(9);
                    row.ModelYear = reader.GetInt16(10);
                    row.OrderStatus = reader.GetByte(14);
                    row.OrderDate = reader.GetDateTime(15);
                    row.RequiredDate = reader.GetDateTime(16);
                    try {
                        row.ShippedDate = reader.GetDateTime(17);
                    } catch (Exception e) {
                        row.ShippedDate = null;
                    }
                    row.StoreId = reader.GetInt32(18);
                    row.StaffId = reader.GetInt32(19);
                    list.Add(row);
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

            return list;
        }
    }
}
