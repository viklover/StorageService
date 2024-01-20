using Microsoft.AspNetCore.Mvc;

using Api.DTOs;
using Api.Exceptions;

using Core.Storage.Interfaces;

namespace Api.Controllers;

/// <summary>
/// Storage api controller
/// </summary>
/// <param name="storageService">Storage service instance</param>
[ApiController]
[Route("storage/{key}")]
public class StorageController(IStorageService storageService) : ControllerBase
{
    /// <summary>
    /// Put variable in storage
    /// </summary>
    /// <param name="key">Variable name</param>
    /// <param name="valueDto">Variable value</param>
    /// <response code="200">Success</response>
    [HttpPut]
    public async Task PutValueByKey(string key, [FromBody] ValueDto valueDto)
    {
        await storageService.SavePairAsync(key, valueDto.Value);
    }

    /// <summary>
    /// Get value by variable name
    /// </summary>
    /// <param name="key">Variable name</param>
    /// <returns>Variable value</returns>
    /// <response code="200">Success</response>
    /// <response code="404">Variable is not exists</response>
    [HttpGet]
    public async Task<string> GetValueByKey(string key)
    {
        var value = await storageService.GetValueByKey(key);

        if (value == null)
        {
            throw new NotFoundException(key);
        }

        return value;
    }

    /// <summary>
    /// Delete pair by variable name
    /// </summary>
    /// <param name="key">Variable name</param>
    /// <response code="200">Success</response>
    [HttpDelete]
    public async Task DeletePairByKey(string key)
    {
        await storageService.DeletePairByKeyAsync(key);
    }
}