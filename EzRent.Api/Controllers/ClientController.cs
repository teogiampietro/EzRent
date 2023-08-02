using AutoMapper;
using EzRent.Service.Client.Command;
using EzRent.Service.Client.Query;
using EzRent.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EzRent.Server.Controllers;

public class ClientController : MainController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClientController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<List<ClientDto>> Get()
    {
        return _mapper.Map<List<ClientDto>>(await _mediator.Send(new GetClientsQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<ClientDto> Get(int id)
    {
        return _mapper.Map<ClientDto>(await _mediator.Send(new GetClientByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PropertyDto request)
    {
        await _mediator.Publish(_mapper.Map<ClientCommand>(request));

        return Ok(request);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PropertyDto request)
    {
        await _mediator.Publish(_mapper.Map<UpdateClientCommand>(request));

        return Ok(request);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Publish(new DeleteClientByIdCommand(id));
        
        return Ok();
    }
}