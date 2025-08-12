using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Services.Dtos;

public class CriarCarteiraDto
{
    public string Nome { get; set; }
    public string CPFCNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public decimal Saldo { get; set; }
    public decimal Limite { get; set; }
    public UsuarioTypeEntity UsuarioType { get; set; }
}