using AutoMapper;
using EzRent.Domain.Entities;
using EzRent.Service.Property.Queries;
using Microsoft.AspNetCore.Mvc;
using EzRent.Shared;
using MediatR;

namespace EzRent.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PropertyController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<List<PropertyDto>> Get()
    {
        return _mapper.Map<List<PropertyDto>>(await _mediator.Send(new GetPropertiesQuery()));
    }

    [HttpPost]
    public async Task<List<Property>> Post()
    {
        return await _mediator.Send(new GetPropertiesQuery());
    }
    
    
    //return Enumerable.Range(1, 5).Select(index => new PropertyDto
    //     {
    //         Name = $"Casa {index}",
    //          Price = index * 10000,
    //         RentPrice = (index * 10000) / 12,
    //         Environments = Random.Shared.Next(1, 5),
    //     })
    //    .ToArray();
}