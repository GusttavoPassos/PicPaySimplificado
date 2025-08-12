using PicPaySimplificado.Models;
using PicPaySimplificado.Repositories;

namespace PicPaySimplificado.Utils;
using RecebedorType = PicPaySimplificado.Models.RecebedorType;

public class EncontrarCarteira
{
    private readonly CarteiraRepository _carteiraRepository;

    public EncontrarCarteira(CarteiraRepository carteiraRepository)
    {
        _carteiraRepository = carteiraRepository;
    }
    
    public async Task<CarteiraEntity?> execute(string recebedor, string recebedorType)
    {
        if (recebedorType == "CPFCNPJ") return await _carteiraRepository.GetCarteiraByCpfCnpj(recebedor); 
        if(recebedorType == "EMAIL") return await _carteiraRepository.GetCarteiraByEmail(recebedor);
        if(recebedorType == "TELEFONE") return await _carteiraRepository.GetCarteiraByTelefone(recebedor);
        return null;
    }
}