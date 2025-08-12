using System.ComponentModel.DataAnnotations;
using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Models.Entities;

public class TransacaoEntity
{
    public TransacaoEntity(Guid idPagador, Guid idRecebedor, decimal valor,  DateTime dataTransacao, TransacaoTypeEntity tipoTransacao, TransacaoStatusTypeEntity statusTransacao)
    {
        IdTransferencia =  Guid.NewGuid();
        IdPagador = idPagador;
        IdRecebedor = idRecebedor;
        Valor = valor;
        DataTransacao = dataTransacao;
        TipoTransacao = tipoTransacao;
        TransacaoStatus = statusTransacao;
    }
    [Key]
    public Guid IdTransferencia { get; init; }
    public Guid IdPagador { get; set; }
    public Guid IdRecebedor { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataTransacao { get; set; }
    public TransacaoTypeEntity  TipoTransacao { get; set; }
    
    public TransacaoStatusTypeEntity TransacaoStatus { get; set; }
    
    public TransacaoEntity() { }
}