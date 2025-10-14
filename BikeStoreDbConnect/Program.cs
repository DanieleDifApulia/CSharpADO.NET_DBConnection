
using BikeStoreDbConnect.DBAccess.Service;
using BikeStoreDbConnect.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;



void StampaMenu()
{
    Console.Clear();
    Console.WriteLine("=== MENU PRINCIPALE ===");
    Console.WriteLine("1. Ricerca Prodotto per Id");
    Console.WriteLine("2. Mostra tutti i prodotti");
    Console.WriteLine("3. Ricerca Negozio per Id");
    Console.WriteLine("4. Mostra tutti i Negozi");
    Console.WriteLine("5. Mostra il numero prodotti");
    Console.WriteLine("6. Ordini prodotti ordinati per status");
    Console.WriteLine("7. Esci");
    Console.Write("Scegli un'opzione (1-7): ");
}

int VerificaInt(string a)
{
    bool verifica = true;
    int valore;
    do
    {
        if (int.TryParse(a, out valore))
        {
            verifica = true;
        }
        if (!int.TryParse(a, out valore))
        {
            verifica = false;
            Console.WriteLine("Non è stato inserito un numero");
            Console.WriteLine("Inserisci nuovamente");
            a = Console.ReadLine();
        }
        else if (valore < 0)
        {
            Console.WriteLine("Il numero inserito è minore di 0");
            Console.WriteLine("Inserisci nuovamente");
            a = Console.ReadLine();
        }
    } while (valore < 0 || verifica == false);
    return valore;
}

float VerificaFloat(string a)
{
    bool verifica = true;
    float valore;
    do
    {
        if (float.TryParse(a, out valore))
        {
            verifica = true;
        }
        if (!float.TryParse(a, out valore))
        {
            verifica = false;
            Console.WriteLine("Non è stato inserito un numero");
            Console.WriteLine("Inserisci nuovamente");
            a = Console.ReadLine();
        }
        else if (valore < 0)
        {
            Console.WriteLine("Il numero inserito è minore di 0");
            Console.WriteLine("Inserisci nuovamente");
            a = Console.ReadLine();
        }
    } while (valore < 0 || verifica == false);
    return valore;
}


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

void StampaNegozi(List<Store> lista)
{

    foreach (var p in lista) //Per ogni oggetto generale nell lista di oggetti
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine(p.ToString());
        Console.WriteLine("-------------------------------------------- \n");
    }

}



void GetProdById_Proc(ProductRepository repository) {  //Proc Inserimento utente ,  Recupero dati e stampa
    Console.WriteLine("----------------- Recupera prodotto per id");
    Product prod = new Product();
    Console.Write("Inserisci id prodotto da cercare : ");
    int id = VerificaInt(Console.ReadLine());
    prod = repository.GetByID(id);
    if (prod.Id == 0)  //Se id è zero significa che non ha trovato niente nel db
    {
        Console.Write("Prodotto non trovato");
    }
    else {
        Console.WriteLine(prod);
        Console.WriteLine();
    }
 
}

void GetAllStores_Proc(StoreRepository repository){  //Proc   Recupero dati e stampa
    Console.WriteLine("----------------- Recupera tutti i negozi");
    List<Store> stores = new List<Store>();
    Console.WriteLine("Lista ");
    stores = repository.GetAllStores(); //Assegna la lista dei prodotti 
    StampaNegozi(stores);

    if (stores.Count == 0) //Se trova zero prodotti 
    {
        Console.Write("Prodotti non trovato");
    }
    else //Se ne trova almeno uno 
    {
        StampaNegozi(stores);
    }

}


void GetStoreById_Proc(StoreRepository repository)
{  //Proc Inserimento utente ,  Recupero dati e stampa
    Console.WriteLine("----------------- Recupera negozio per id");
    Store store = new Store();
    Console.Write("Inserisci id negozio da cercare : ");
    int id = VerificaInt(Console.ReadLine());
    store = repository.GetByID(id);
    if (store.StoreId == 0)  //Se id è zero significa che non ha trovato niente nel db
    {
        Console.Write("Negozio non trovato");
    }
    else
    {
        Console.WriteLine(store);
        Console.WriteLine();
    }

}

void GetAllProducts_Proc(ProductRepository repository)
{  //Proc   Recupero dati e stampa
    Console.WriteLine("----------------- Recupera tutti i prodotti");
    List<Product> products = new List<Product>();
    Console.WriteLine("Lista ");
    products = repository.GetAllProducts(); //Assegna la lista dei prodotti 
    StampaProdotti(products);

    if (products.Count == 0) //Se trova zero prodotti 
    {
        Console.Write("Prodotti non trovato");
    }
    else //Se ne trova almeno uno 
    {
        StampaProdotti(products);
    }

}



void StampaLista(List<Product_OrderItems_Orders> list ) {
    foreach (var item in list)
    {

        Console.WriteLine(item.ToString());
    }
}




void Prodotti_Ordini_Proc(Product_OrderItem_Orders_Repository repository)
{  //Proc   Recupero dati e stampa
    Console.WriteLine("----------------- Recupera tutti i prodotti");
    List<Product_OrderItems_Orders> ordiniProdotti = new List<Product_OrderItems_Orders>();
    Console.Write("Inserisci lo status di ricerca : ");
    int x = VerificaInt(Console.ReadLine());
    ordiniProdotti = repository.GetOrdiniProdotti(x); //Assegna la lista dei prodotti 
  

    if (ordiniProdotti.Count == 0) //Se trova zero prodotti 
    {
        Console.Write("Prodotti non trovato");
    }
    else //Se ne trova almeno uno 
    {
        StampaLista(ordiniProdotti);
    }

}

void GetProductsCount_Proc(ProductRepository repository) { 
    Console.WriteLine("######### Count prodotti #########");
    Console.WriteLine("Numero Prodotti : "+ repository.CountProducts());
}

//-------------- Main del programma
Console.WriteLine("######### Bike Store DB #########");

        //Istanze 
ProductRepository repository = new ProductRepository();
StoreRepository  repositoryStores = new StoreRepository();
Product_OrderItem_Orders_Repository repoOrdini = new Product_OrderItem_Orders_Repository();
Product prod = new Product();
List<Product> products = new List<Product>();

bool continua = true;
while (continua)   //Menu
{
    StampaMenu();

    string scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            GetProdById_Proc( repository );
            break;
        case "2":
            GetAllProducts_Proc(repository );
            break;
        case "3":
            GetStoreById_Proc( repositoryStores );
            break;
        case "4":
            GetAllStores_Proc(repositoryStores );
            break;
        case "5":
            GetProductsCount_Proc(repository);
            break;
        case "6":
            Prodotti_Ordini_Proc(repoOrdini);
            break;
        case "7":
            continua = false;
            break;
        default:

            break;
    }

    if (continua)
    {
        Console.WriteLine("\nPremi un tasto per continuare...");
        Console.ReadKey();
    }
}





