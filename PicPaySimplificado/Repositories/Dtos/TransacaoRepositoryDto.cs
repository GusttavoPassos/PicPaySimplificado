using PicPaySimplificado.Models;
using PicPaySimplificado.Models.Entities;
using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Repositories.Dtos;

public interface TransacaoRepositoryDto
{
    Task<TransacaoEntity?> CriarTransacao(TransacaoRequest request);
    Task<string> UpdateTransacao(TransacaoEntity transacao);
    Task CommitAsync();

    // 🔹 Novos métodos de busca
    Task<TransacaoEntity?> GetTransacaoById(Guid id);
    Task<List<TransacaoEntity>> GetTransacoesByPagador(Guid idPagador);
    Task<List<TransacaoEntity>> GetTransacoesByRecebedor(Guid idRecebedor);
    Task<List<TransacaoEntity>> GetTransacoesByStatus(TransacaoStatusTypeEntity status);
}