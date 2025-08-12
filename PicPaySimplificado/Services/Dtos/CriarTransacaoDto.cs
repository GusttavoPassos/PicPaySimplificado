using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PicPaySimplificado.Migrations;
using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Services.Dtos;

public class CriarTransacaoDto
{
    public Guid idPagador { get; set; }
    public string recebedor { get; set; }
    public string recebedorType  { get; set; }
    public decimal valor { get; set; }
   
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TransacaoTypeEntity tipoTransacao { get; set; }
}