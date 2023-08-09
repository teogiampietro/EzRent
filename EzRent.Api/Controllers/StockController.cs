using AutoMapper;
using EzRent.Domain.Entities;
using EzRent.Service.Product.Command;
using EzRent.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EzRent.Server.Controllers;

public class StockController : MainController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StockController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] List<StockUpdateDto> request)
    {
        var productsToUpdate = _mapper.Map<List<Product>>(request);
        
        await _mediator.Publish(new UpdateProductStockCommand(productsToUpdate));
        
        return Ok();
    }
}