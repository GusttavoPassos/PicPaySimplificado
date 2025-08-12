using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Services;
using PicPaySimplificado.Services.Dtos;

namespace PicPaySimplificado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarteiraController : ControllerBase
{
    private readonly CarteiraService _service;

    public CarteiraController(CarteiraService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarCarteiraDto dto)
    {
        var result = await _service.CriarCarteira(dto);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> BuscarPeloId(Guid id)
    {
        var result = await _service.BuscarPorId(id);
        return result is not null ? Ok(result) : NotFound("Carteira não encontrada");
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> BuscarPeloEmail(string email)
    {
        var result = await _service.BuscarPorEmail(email);
        return result is not null ? Ok(result) : NotFound("Carteira não encontrada");
    }

    [HttpGet("cpfcnpj/{cpfcnpj}")]
    public async Task<IActionResult> BuscarPeloCPFCNPJ(string cpfcnpj)
    {
        var result = _service.BuscarPorCpfCnpj(cpfcnpj);
        return result is not null ? Ok(result) : NotFound("Carteira Não Encontrada");
    }

    [HttpGet("telefone/{telefone}")]
    public async Task<IActionResult> BuscarPeloTelefone(string telefone)
    {
        var result = _service.BuscarPorTelefone(telefone);
        return result is not null ? Ok(result) : NotFound("Carteira não Encontrada");
    }
}