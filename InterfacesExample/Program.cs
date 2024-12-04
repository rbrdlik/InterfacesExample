using InterfacesExample;

IModel model;

// model = new CarModel("superb", "skoda");
model = new RocketModel("superb", 161);

var repository = new CarCsvFileRepository();
var cars = repository.Get();
foreach (var car in cars)
{
    Console.WriteLine($"{car.Name} {car.Id} {car.Brand} {car.DateModified} {car.DateCreate}");
}