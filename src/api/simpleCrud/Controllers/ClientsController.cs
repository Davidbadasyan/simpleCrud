namespace simpleCrud.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("")]
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] ClientDto request)
    {
        var command = new CreateClientCommand(request);
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [Route("{id:long}")]
    [HttpPut]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] long id,
        [FromBody] ClientDto request)
    {
        var command = new UpdateClientCommand(id, request);
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteByIdAsync([FromRoute] long id)
    {
        var command = new DeleteClientCommand(id);
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<ActionResult> GetByIdAsync([FromRoute] long id)
    {
        var command = new GetClientByIdQuery(id);
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [Route("")]
    [HttpGet]
    public async Task<ActionResult> GetPaginatedAsync(
        [FromQuery] string search = "",
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var command = new GetPaginatedClientsQuery(pageNumber, pageSize, search);
        var response = await _mediator.Send(command);

        return Ok(response);
    }

}