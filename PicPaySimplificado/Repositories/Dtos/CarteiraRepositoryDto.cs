using PicPaySimplificado.Infra;
using PicPaySimplificado.Models;

namespace PicPaySimplificado.Repositories.Dtos;

public interface CarteiraRepositoryDto
{
    
    Task CreateCarteira(CarteiraEntity carteira);
    
    Task UpdateCarteira(CarteiraEntity carteira);
    
    Task<CarteiraEntity?> GetCarteiraById(Guid id);
    
    Task<CarteiraEntity?> GetCarteiraByCpfCnpj(string cpfCnpj);
    
    Task<CarteiraEntity?> GetCarteiraByEmail(string email);
    
    Task<CarteiraEntity?> GetCarteiraByTelefone(string telefone);
    
    Task <string> ProcessarSaldo(ProcessarTransacaoRequest request);
    
    Task <string> ProcessarCredito(ProcessarTransacaoRequest request);
    
    Task CommitAsync(); 
}