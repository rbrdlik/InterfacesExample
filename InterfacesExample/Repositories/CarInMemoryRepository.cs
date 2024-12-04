namespace InterfacesExample;

public class CarInMemoryRepository : IRespository<CarModel>
{
    public List<CarModel> cars = new();
    public CarModel? Get(Guid Id)
    {
        foreach (var carModel in cars)
        {
            if (carModel.Id == Id)
            {
                return carModel;
            }
        }
        return null;
    }

    public List<CarModel> Get()
    {
        return cars;
    }

    public void Insert(CarModel model)
    {
        if (model != null)
        {
            cars.Add(model);
        }
    }

    public void Update(CarModel model)
    {
        CarModel existingModel = Get(model.Id);

        if (existingModel != null)
        {
            existingModel.Name = model.Name;
            existingModel.Brand = model.Brand;
        }
    }

    public void Delete(Guid Id)
    {
        CarModel carToDelete = Get(Id);
        if (carToDelete != null)
        {
            cars.Remove(carToDelete);
        }
    }

    public int RecordCount()
    {
        return cars.Count;
    }
}