using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Models;

public record TransacaoRequest(TransacaoTypeEntity tipo, decimal valor, Guid recebedor, Guid pagador, DateTime date, TransacaoStatusTypeEntity status);

public enum RecebedorType
{
    CPFCNPJ,
    EMAIL,
    TELEFONE,
}