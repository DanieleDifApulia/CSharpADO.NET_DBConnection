



using BikeStoreDbConnect.DBAccess.Service;
using BikeStoreDbConnect.Model;




Console.WriteLine("######### Bike Store DB #########à");
ProductRepository repository = new ProductRepository();
Product prod = new Product();
prod = repository.GetByID();
Console.WriteLine(prod);
