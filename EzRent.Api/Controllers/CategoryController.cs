using AutoMapper;
using EzRent.Service.Category.Command;
using EzRent.Service.Category.Query;
using EzRent.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EzRent.Server.Controllers;

public class CategoryController : MainController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<List<CategoryDto>> Get()
    {
        return _mapper.Map<List<CategoryDto>>(await _mediator.Send(new GetCategoriesQuery()));
    }
    
    [HttpGet("{id:int}")]
    public async Task<CategoryDto> Get(int id)
    {
        return _mapper.Map<CategoryDto>(await _mediator.Send(new GetCategoryByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryDto request)
    {
        await _mediator.Publish(_mapper.Map<CategoryCommand>(request));

        return Ok(request);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CategoryDto request)
    {
        await _mediator.Publish(_mapper.Map<UpdateCategoryCommand>(request));

        return Ok(request);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Publish(new DeleteCategoryByIdCommand(id));
        
        return Ok();
    }
}