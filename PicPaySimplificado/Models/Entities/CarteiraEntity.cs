using PicPaySimplificado.Models.Enum;

namespace PicPaySimplificado.Models;

public class CarteiraEntity
{

    public CarteiraEntity(string nome, string cpfcnpj, string email, string senha, string telefone, decimal saldo, decimal limite, UsuarioTypeEntity usertype)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CPFCNPJ = cpfcnpj;
        Email = email;
        Senha = senha;
        Telefone = telefone;
        Saldo = saldo;
        Limite = limite;
        UsuarioTypeEntityType = usertype;
    }
    public Guid Id { get; init; }
    public string Nome { get; set; }
    public string CPFCNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public decimal Saldo { get; set; }
    
    public decimal Limite {get; set;}
    public UsuarioTypeEntity UsuarioTypeEntityType { get; set; }
    
    public CarteiraEntity() { }
}