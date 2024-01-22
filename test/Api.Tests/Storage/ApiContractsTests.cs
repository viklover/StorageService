using Api.Controllers;
using Api.Exceptions;
using Api.Storage.Mock;

namespace Api.Storage;

public class ApiContractsTests
{
    private readonly StorageController _controller = new(new FakeStorageService());
    
    [Fact]
    public void NotFoundException()
    {
        Assert.ThrowsAsync<NotFoundException>(async() => await _controller.GetValueByKey("Hello"));
    }
}