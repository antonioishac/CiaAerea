using CiaAerea.Services;
using CiaAerea.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CiaAerea.Controllers;

[Route("api/aeronaves")]
[ApiController]
[Produces("application/json")]
public class AeronaveController : ControllerBase
{ 
    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }

    /// <summary>
    /// Adicionar Aeronaves.
    /// </summary>
    /// <param name="dados"></param>
    /// <returns></returns>
    /// <response code="201">Retorna os dados da aeronave cadastrada</response>
    [HttpPost]
    [ProducesResponseType(typeof(DetalhesAeronaveViewModel), StatusCodes.Status201Created)]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = _aeronaveService.AdicionarAeronave(dados);
        
        return CreatedAtAction(
            nameof(ListarAeronavePeloId), 
            new {id = aeronave.Id}, 
            aeronave);
    }

    /// <summary>
    /// Listar Aeronaves.
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Retorna todas as aeronaves cadastrada</response>
    [HttpGet]
    public IActionResult ListarAeronaves()
    {
        return Ok(_aeronaveService.ListarAeronaves());
    }

    [HttpGet("{id}")]
    public IActionResult ListarAeronavePeloId(int id)
    {
        var aeronave = _aeronaveService.ListarAeronavePeloId(id);
        if (aeronave != null)
        {
            return Ok(aeronave);
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
    {
        if (id != dados.Id)
            return BadRequest("O Id informado na URL é diferente do Id informado no corpo da requisição");

        var aeronave = _aeronaveService.AtualizarAeronave(dados);
        return Ok(aeronave);
    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirAeronave(int id)
    {
        _aeronaveService.ExcluirAeronave(id);
        return NoContent();
    }
}