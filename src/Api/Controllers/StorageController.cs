using Microsoft.AspNetCore.Mvc;

using Api.DTOs;
using Api.Exceptions;

using Core.Storage;

namespace Api.Controllers;

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