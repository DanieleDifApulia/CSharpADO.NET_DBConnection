
using BikeStoreDbConnect.DBAccess.Service;
using BikeStoreDbConnect.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
void MenuGestioneProdotti(ProductRepository productRepository)
{
    bool continua = true;
    int scelta = 0;
    while (continua)   //Menu
    {
        StampaMenuGestioneProdotti();

        scelta = VerificaInt(Console.ReadLine());

        switch (scelta)
        {
            case 1:
                Console.WriteLine("1. ---------- Inserisci Prodotto");
                InsertProduct(productRepository);
                break;
            case 2:
                Console.WriteLine("2. ---------- Modifica Prodotto per id");
                UpdateProduct(productRepository);
                break;
            case 3:
                Console.WriteLine("3. ---------- Elimina Prodotto per id");
                DeleteProduct(productRepository);
                break;
            case 4:
                Console.WriteLine("4. ---------- Ricerca Prodotto per id");
                GetProdById_Proc(productRepository);
                break;
            case 5:
                Console.WriteLine("5. ---------- Mostra tutti i prodotti");
                GetAllProducts_Proc(productRepository);
                break;
            case 6:
                Console.WriteLine("6. ---------- Mostra il numero prodotti");
                GetProductsCount_Proc(productRepository);
                break;
            case 7:
                Console.WriteLine("7. ---------- Ordini prodotti ordinati per status");
                break;
            case 8:
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
}

void StampaMenuGestioneProdotti()
{
    Console.Clear();
    Console.WriteLine("=== MENU GESTIONE PRODOTTI ===");
    Console.WriteLine("1. Inserisci Prodotto");
    Console.WriteLine("2. Modifica prodotto per Id");
    Console.WriteLine("3. Elimina prodotto per Id");
    Console.WriteLine("4. Ricerca Prodotto per Id");
    Console.WriteLine("5. Mostra tutti i prodotti");
    Console.WriteLine("6. Mostra il numero prodotti");
    Console.WriteLine("7. Ordini prodotti ordinati per status");
    Console.WriteLine("8. Esci");
    Console.Write("Scegli un'opzione (1-8): ");
}


bool InsertProduct(ProductRepository repository)
{
    bool conferma = true; //Flag per uscita dell ' inserimento
    string confirmStr = "";
    Product product = new Product();
    while (conferma)
    {
        product.Model = SecureStringInsert("Inserisci Modello : ");
        product.BrandId = SecureIntInsert("Inserisci Brand Id : ");
        product.Price = SecureDecimalInsert("Insersci Prezzo : ");
        product.ModelYear = SecureIntInsert("Inserisci Anno del Modello : ");
        product.CategoryId = SecureIntInsert("Inserisci la Categoria  : ");
        Console.WriteLine("Confermi il prodotto ?");
        confirmStr = SecureStringInsert(" ");
        if (confirmStr == "Y" || confirmStr == "y")
        {
            conferma = false;
        }
    } 
    return repository.Insert(product);
}


bool DeleteProduct(ProductRepository repository)
{
    bool conferma = true; //Flag per uscita dell ' inserimento
    string confirmStr = " ";
    Product product = new Product();
    while (conferma)
    {
        product.Id = SecureIntInsert("Inserisci ID Modello :  "); 
        product = repository.GetByID(product.Id); //Prende il prodotto by id
        Console.WriteLine(product.ToString());//Stampa dell' prodotto
        while (confirmStr != null) {
            Console.WriteLine("\nConfermi il prodotto ? Y o N ");
            confirmStr = Console.ReadLine();
            if (confirmStr == "Y" || confirmStr == "y")
            {
                conferma = false;
                break;
            }
        }
    }  
    return repository.Delete(product.Id);
}

bool UpdateProduct(ProductRepository repository) {
    bool conferma = true; //Flag per uscita dell ' inserimento
    string confirmStr = " ";
    string inpString = "";
    int inpInt = 0;
    decimal inpDec = 0;
    bool isIntFlag = false;
    bool isDecFlag = false;
    Product product = new Product();
    while (conferma)
    {
        product.Id = SecureIntInsert("Inserisci ID Modello da Modificare : ");
        product = repository.GetByID(product.Id); //Prende il prodotto by id
        Console.WriteLine(product.ToString());//Stampa dell' prodotto
        Console.Write("Inserisci Modello : ");
        inpString = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(inpString)) {
            product.Model = inpString;
        }
        Console.Write("Inserisci Id Brand : ");
        isIntFlag = int.TryParse(Console.ReadLine(), out inpInt);
        if (!isIntFlag)
        {
            product.BrandId = inpInt;
        }
        Console.Write("Inserisci Model Year : ");
        isIntFlag = int.TryParse(Console.ReadLine(), out inpInt);
        if (!isIntFlag)
        {
            product.ModelYear = inpInt;
        }
        Console.Write("Inserisci list price : ");
        isIntFlag = decimal.TryParse(Console.ReadLine(), out inpDec);
        if (!isIntFlag)
        {
            product.Price = inpDec;
        }
        Console.Write("IL sara aggiornato cosi ");
        Console.WriteLine(product.ToString());
        while (true) {
            Console.Write("Inserisci Confermi ? Y o N : ");
            inpString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inpString))
            {
                Console.Write("Non hai inserito niente");
            }
            else {
                break;
            }
        }
    }
    return repository.Update(product);
}

void StampaMenu()
{
    Console.Clear();
    Console.WriteLine("=== MENU PRINCIPALE ===");
    Console.WriteLine("1. Gestione prodotti");
    Console.WriteLine("2. Gestion negozi");
    Console.WriteLine("3. Gestione Ordini");
    Console.WriteLine("4. Esci");
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


decimal VerificaDecimal(string a)
{
    bool verifica = true;
    decimal valore;
    do
    {
        if (decimal.TryParse(a, out valore))
        {
            verifica = true;
        }
        if (!decimal.TryParse(a, out valore))
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

string SecureStringInsert(string msg) { //Controlla e richiede l' inserimento 
    string str = "";
    string confirmStr;
    bool confirm = true;
    while (confirm) {
        Console.Write(msg);
        str = Console.ReadLine();
        if(str != null) //Se la stringa e diversa da null 
        {
            while (confirm)
            {
                Console.Write("Confermi ? Y or N  : ");
                confirmStr = Console.ReadLine();
                if (confirmStr == "Y" || confirmStr == "y")
                {
                    confirm = false;
                }
                else
                {
                    break;
                }
            }
        }
    }
    return str;
}

int SecureIntInsert(string msg)
{ //Controlla e richiede l' inserimento 
    int x = 0;
    string str = "";
    string confirmStr;
    bool   confirm = true;
    bool isInt = false;
    while (confirm)
    {
        Console.Write(msg);
        isInt = int.TryParse(Console.ReadLine(),out x);
        if (isInt) //Se la stringa e diversa da null 
        {
            while (confirm)
            {
                Console.Write("Confermi ? Y or N : ");
                confirmStr = Console.ReadLine();
                if (confirmStr == "Y" || confirmStr == "y")
                {
                    confirm = false;
                }
                else
                {
                    break;
                }
            }
        }
    }
    return x;
}

decimal SecureDecimalInsert(string msg)
{ //Controlla e richiede l' inserimento 
    decimal x = 0;
    string str = "";
    string confirmStr;
    bool confirm = true;
    bool isDec = false;
    while (confirm)
    {
        Console.Write(msg);
        isDec = decimal.TryParse(Console.ReadLine(), out x);
        if (isDec) //Se la stringa e diversa da null 
        {
            while (confirm)
            {
                Console.Write("Confermi ? Y or N : ");
                confirmStr = Console.ReadLine();
                if (confirmStr == "Y" || confirmStr == "y")
                {
                    confirm = false;
                }
                else {
                    break;
                }
            }
        }
    }
    return x;
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
ProductRepository productRepository = new ProductRepository();
StoreRepository  repositoryStores = new StoreRepository();
Product_OrderItem_Orders_Repository repoOrdini = new Product_OrderItem_Orders_Repository();
List<Product> products = new List<Product>();


bool continua = true;
while (continua)   //Menu
{
    StampaMenu();

    string scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            MenuGestioneProdotti(productRepository);
            break;
        case "2":
            Console.WriteLine("2.-------- Gestione negozi");
            break;
        case "3":
            Console.WriteLine("3.-------- Gestione Ordini");
            break;
        case "4":
            GetAllStores_Proc(repositoryStores );
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





