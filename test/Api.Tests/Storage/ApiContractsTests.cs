using Api.Controllers;
using Api.Exceptions;

using Core.Storage.Impl.Fake;

namespace Api.Storage;

public class ApiContractsTests
{
    private StorageController _controller = new(new FakeStorageService());
    
    [Fact]
    public void NotFoundException()
    {
        Assert.Throws<NotFoundException>(() => _controller.GetValueByKey("Hello"));
    }
}