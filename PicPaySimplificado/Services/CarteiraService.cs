using PicPaySimplificado.Models;
using PicPaySimplificado.Repositories;
using PicPaySimplificado.Services.Dtos;

namespace PicPaySimplificado.Services;

public class CarteiraService
{
    private readonly CarteiraRepository _carteiraRepository;

    public CarteiraService(CarteiraRepository carteiraRepository)
    {
        _carteiraRepository = carteiraRepository;
    }

    public async Task<string> CriarCarteira(CriarCarteiraDto data)
    {
        try
        {
            var novaCarteira = new CarteiraEntity(
                data.Nome,
                data.CPFCNPJ,
                data.Email,
                data.Senha,
                data.Telefone,
                data.Saldo,
                data.Limite,
                data.UsuarioType
            );

            await _carteiraRepository.CreateCarteira(novaCarteira);
            await _carteiraRepository.CommitAsync();

            return "Carteira criada com sucesso!";
        }
        catch (Exception ex)
        {
            return $"Erro ao criar carteira: {ex.Message}";
        }
    }

    public async Task<string> AtualizarCarteira(CarteiraEntity carteira)
    {
        try
        {
            await _carteiraRepository.UpdateCarteira(carteira);
            await _carteiraRepository.CommitAsync();

            return "Carteira atualizada com sucesso!";
        }
        catch (Exception ex)
        {
            return $"Erro ao atualizar carteira: {ex.Message}";
        }
    }

    public async Task<CarteiraEntity?> BuscarPorId(Guid id)
    {
        return await _carteiraRepository.GetCarteiraById(id);
    }

    public async Task<CarteiraEntity?> BuscarPorCpfCnpj(string cpfCnpj)
    {
        return await _carteiraRepository.GetCarteiraByCpfCnpj(cpfCnpj);
    }

    public async Task<CarteiraEntity?> BuscarPorEmail(string email)
    {
        return await _carteiraRepository.GetCarteiraByEmail(email);
    }

    public async Task<CarteiraEntity?> BuscarPorTelefone(string telefone)
    {
        return await _carteiraRepository.GetCarteiraByTelefone(telefone);
    }
}