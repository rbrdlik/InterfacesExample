// ReSharper disable All
namespace InterfacesExample.Tests;

public class CarInMemoryRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        //Arrange
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        int RecordCountBefore = model.RecordCount();
        
        //Act
        model.Insert(carModel);
        int RecordCountAfter = model.RecordCount();

        //Assert
        Assert.Equal(RecordCountBefore,  RecordCountAfter - 1);
    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        //Arrange
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = null;
        int RecordCountBefore = model.RecordCount();

        //Act
        if (carModel != null)
        {
            model.Insert(carModel);
        }
        int RecordCountAfter = model.RecordCount();

        //Assert
        Assert.Equal(RecordCountAfter, RecordCountBefore);
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        //Arrange 
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        CarModel carModel2 = new CarModel("octavia", "skoda");

        //Act
        model.Insert(carModel);
        model.Insert(carModel2);

        List<CarModel> models = model.Get();

        //Assert
        Assert.Equal(2, models.Count);
        Assert.Contains(carModel, models);
        Assert.Contains(carModel2, models);
    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        //Arrange 
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        CarModel carModel2 = new CarModel("octavia", "skoda");
        
        //Act
        model.Insert(carModel);
        model.Insert(carModel2);

        CarModel getModel1 = model.Get(carModel.Id);
        CarModel getModel2 = model.Get(carModel2.Id);

        //Assert
        Assert.NotNull(getModel1);
        Assert.NotNull(getModel2);
        Assert.Equal(carModel.Id, getModel1.Id);
        Assert.Equal(carModel2.Id, getModel2.Id);
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        //Arrange 
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        CarModel carModel2 = new CarModel("octavia", "skoda");
        
        //Act
        model.Insert(carModel);
        model.Insert(carModel2);

        Guid nonExistId = new Guid();
        CarModel nonExistCarModel = model.Get(nonExistId);

        //Assert
        Assert.Null(nonExistCarModel);
    }
    
    [Fact]
    public void UpdatingRecord_WithValidId_ShouldUpdatePropeties()
    {
        //Arange
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        model.Insert(carModel);
        Guid CarId = carModel.Id;
        
        //Act
        CarModel updateCarModel = new CarModel("octavia", "neco") { Id = CarId};
        model.Update(updateCarModel);
        
        //Assert
        CarModel updatedCar = model.Get(CarId);
        Assert.NotNull(updatedCar);
        Assert.Equal("octavia", updatedCar.Name);
        Assert.Equal("neco", updatedCar.Brand);
    }

    [Fact]
    public void DeletingExistingRecord_ShouldRemoveTheRecord()
    {
        //Arange
        IRespository<CarModel> model = new CarInMemoryRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        model.Insert(carModel);
        
        //Act
        CarModel deletedCarModel = model.Get(carModel.Id);
        model.Delete(carModel.Id);

        List<CarModel> models = model.Get();
        
        //Assert
        Assert.DoesNotContain(deletedCarModel, models);
    }
}
