namespace InterfacesExample;

public class CarModel : IModel, ICar
{
    public Guid Id { get; set;  }
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            DateModified = DateTime.Now;
        }
    }

    public DateTime DateCreate { get; set; }
    public DateTime DateModified { get; set; }
    
    public string Brand { get; set; }

    public CarModel(string name, string brand)
    {
        Id = Guid.NewGuid();
        Name = name;
        Brand = brand;
        DateCreate = DateTime.Now;
        DateModified = DateTime.Now;
    }

    public CarModel(Guid id, string name, string brand, DateTime dateCreate, DateTime dateModified)
    {
        Id = id;
        _name = name;
        DateCreate = dateCreate;
        DateModified = dateModified;
        Brand = brand;
    }

    public string Describe()
    {
        return $"{Id}: {Brand}({Name})";
    }
}