
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
    Console.WriteLine("3. Esci");
    Console.Write("Scegli un'opzione (1-3): ");
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

void GetAllProducts_Proc(ProductRepository repository){  //Proc   Recupero dati e stampa
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




//-------------- Main del programma
Console.WriteLine("######### Bike Store DB #########");

        //Istanze 
ProductRepository repository = new ProductRepository();
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





