



using BikeStoreDbConnect.DBAccess.Service;
using BikeStoreDbConnect.Model;



/*void StampaQuarySemplice(List<Object> list) {  //NON FUNZIONANTE

    foreach(var item in list) //Per ogni oggetto generale nell lista di oggetti
    {
        Console.WriteLine(item.ToString());
    }

}*/

void StampaProdotti(List<Product> listaProdotti) { 

    foreach(var p in listaProdotti) //Per ogni oggetto generale nell lista di oggetti
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine(p.ToString());
        Console.WriteLine("-------------------------------------------- \n");
    }

}



Console.WriteLine("######### Bike Store DB #########à");
ProductRepository repository = new ProductRepository();
Product prod = new Product();
List<Product> products = new List<Product>();
prod = repository.GetByID(7);


Console.WriteLine("Prodotto singolo");
Console.WriteLine(prod);
Console.WriteLine("Lista ");
products  = repository.GetAllProducts(); //Assegna la lista dei prodotti 
StampaProdotti(products);

