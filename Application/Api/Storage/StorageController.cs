using Microsoft.AspNetCore.Mvc;

using Application.Api.Storage.DTOs;
using Application.Api.Storage.Exceptions;
using Application.Services.Storage;

namespace Application.Api.Storage;

[ApiController]
[Route("storage/{key}")]
public class StorageController(IStorageService storageService) : ControllerBase
{
    [HttpPut]
    public void PutValueByKey(string key, [FromBody] ValueDto valueDto)
    {
        storageService.SaveOrUpdatePair(key, valueDto.Value);
    }
    
    [HttpGet]
    public string GetValueByKey(string key)
    {
        var value = storageService.GetValueByKey(key);

        if (value == null)
        {
            throw new NotFoundException(key);
        }

        return value;
    }
    
    [HttpDelete]
    public void DeletePairByKey(string key)
    {
        storageService.DeletePairByKey(key);
    }
}