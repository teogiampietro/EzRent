using AutoMapper;
using EzRent.Service.Property.Command;
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

    [HttpGet("{id:int}")]
    public async Task<PropertyDto> Get(int id)
    {
        return _mapper.Map<PropertyDto>(await _mediator.Send(new GetPropertyByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PropertyDto request)
    {
        await _mediator.Publish(_mapper.Map<PropertyCommand>(request));

        return Ok(request);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PropertyDto request)
    {
        await _mediator.Publish(_mapper.Map<UpdatePropertyCommand>(request));

        return Ok(request);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Publish(new DeletePropertyByIdCommand(id));
        
        return Ok();
    }
}