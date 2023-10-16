using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Prova.B3.Domain.Model;
using Prova.B3.Services.Interfaces;

namespace Prova.B3.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbController : ControllerBase
{
    
    private readonly ICdbService cdbService;
    private readonly IValidator<Cdb> validator;

    public CdbController(ICdbService cdbService, IValidator<Cdb> validator)
    {
        this.cdbService = cdbService;
        this.validator = validator;
    }

 
    [HttpPost("Calcular")]
    public async Task<IActionResult> CalcAsync([FromBody]Cdb request)
    {
        var validatorResult = validator.Validate(request);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors.Select(c=> c.ErrorMessage));

        var result = await cdbService.CarcularAsync(request);
        return Ok(result);
    }
}
