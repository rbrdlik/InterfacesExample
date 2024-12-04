using System.Globalization;
// ReSharper disable All

namespace InterfacesExample;

public class CarCsvFileRepository : ICar
{
    private readonly string _filePath = "../net8.0/carList.csv";

    public CarCsvFileRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "Id,Brand,Name,DateCreate,DateModified\n");
        }
    }
    public CarModel? Get(Guid Id)
    {
        throw new NotImplementedException();
    }

    public List<CarModel> Get()
    {
        var lines = File.ReadAllLines(_filePath).Skip(1);
        return lines.Select(ParseCsv).Where(car => car != null).ToList();
    }

    public void Insert(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public int RecordCount()
    {
        throw new NotImplementedException();
    }
    
    public CarModel ParseCsv(string line)
    {
        var part = line.Split(",");
        return new CarModel(Guid.Parse(part[0]),part[1], part[2], DateTime.Parse(part[3], CultureInfo.InvariantCulture), DateTime.Parse(part[3], CultureInfo.InvariantCulture));
    }
}
