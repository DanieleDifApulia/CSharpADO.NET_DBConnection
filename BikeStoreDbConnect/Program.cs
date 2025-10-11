


using BikeStoreDbConnect.DBAccess.Service;
using BikeStoreDbConnect.Model;



ProductRepository repository = new ProductRepository();
Product prod = new Product();
prod = repository.GetByID();

