using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EzRent.Shared;

namespace EzRent.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    [HttpGet]
    public IEnumerable<PropertyDto> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new PropertyDto
            {
                Name = $"Casa {index}",
                Price = index * 10000,
                RentPrice = (index * 10000) / 12,
                Environments = Random.Shared.Next(1, 5),
            })
            .ToArray();
    }
}