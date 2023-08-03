using AutoMapper;
using EzRent.Service.Product.Command;
using EzRent.Service.Product.Query;
using Microsoft.AspNetCore.Mvc;
using EzRent.Shared;
using MediatR;

namespace EzRent.Server.Controllers;

public class ProductController : MainController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<List<ProductDto>> Get()
    {
        return _mapper.Map<List<ProductDto>>(await _mediator.Send(new GetProductsQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<ProductDto> Get(int id)
    {
        return _mapper.Map<ProductDto>(await _mediator.Send(new GetProductByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductDto request)
    {
        await _mediator.Publish(_mapper.Map<ProductCommand>(request));

        return Ok(request);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProductDto request)
    {
        await _mediator.Publish(_mapper.Map<UpdateProductCommand>(request));

        return Ok(request);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Publish(new DeleteProductByIdCommand(id));
        
        return Ok();
    }
}