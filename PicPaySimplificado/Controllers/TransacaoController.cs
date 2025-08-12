using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Services;
using PicPaySimplificado.Services.Dtos;
using PicPaySimplificado.Models.Entities;
using PicPaySimplificado.Repositories;

namespace PicPaySimplificado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly TransacaoService _service;

    public TransacaoController(TransacaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarTransacaoDto dto)
    {
        var resultado = await _service.CriarTransacao(dto);
        return Ok(resultado);
    }
    
    [HttpPost("processar")]
    public async Task<IActionResult> Processar([FromBody] TransacaoEntity transacao)
    {
        var resultado = await _service.ProcessarTransacao(transacao);
        return Ok(resultado);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> BuscarPorId(Guid id, [FromServices] TransacaoRepository repository)
    {
        var transacao = await repository.GetTransacaoById(id);
        return transacao is not null ? Ok(transacao) : NotFound("Transação não encontrada");
    }
}