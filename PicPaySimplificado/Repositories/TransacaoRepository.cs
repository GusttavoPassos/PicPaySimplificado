using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Infra;
using PicPaySimplificado.Models;
using PicPaySimplificado.Models.Entities;
using PicPaySimplificado.Repositories.Dtos;
using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Repositories;

public class TransacaoRepository : TransacaoRepositoryDto
{
    private readonly AppDbContext _context;

    public TransacaoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<TransacaoEntity?> CriarTransacao(TransacaoRequest request)
    {
        try
        {
            TransacaoEntity transacao = new TransacaoEntity(
                request.pagador,
                request.recebedor,
                request.valor,
                request.date,
                request.tipo,
                request.status
            );
            await _context.Transacoes.AddAsync(transacao);
            return transacao;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> UpdateTransacao(TransacaoEntity transacao)
    {
        try
        {
            _context.Transacoes.Update(transacao);
            return "Sucesso!";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task CommitAsync()
    {
        try
        {
            return _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<TransacaoEntity?> GetTransacaoById(Guid id)
    {
        try
        {
            return await _context.Transacoes.FirstOrDefaultAsync(t => t.IdTransferencia == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<TransacaoEntity>> GetTransacoesByPagador(Guid idPagador)
    {
        try
        {
            return await _context.Transacoes
                .Where(t => t.IdPagador == idPagador)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<TransacaoEntity>> GetTransacoesByRecebedor(Guid idRecebedor)
    {
        try
        {
            return await _context.Transacoes
                .Where(t => t.IdRecebedor == idRecebedor)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<TransacaoEntity>> GetTransacoesByStatus(TransacaoStatusTypeEntity status)
    {
        try
        {
            return await _context.Transacoes
                .Where(t => t.TransacaoStatus == status)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
