using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("storage/{key}")]
public class StorageController : ControllerBase
{
    [HttpPut]
    public string PutValueByKey([FromRoute] string key, [FromBody] ValueDto valueDto)
    {
        return "NOT IMPLEMENTED";
    }
    
    [HttpGet]
    public string GetValueByKey([FromRoute] string key)
    {
        return "NOT IMPLEMENTED";
    }
    
    [HttpDelete]
    public string DeletePairByKey([FromRoute] string key)
    {
        return "NOT IMPLEMENTED";
    }
}