using PicPaySimplificado.Models;
using PicPaySimplificado.Models.Entities;
using PicPaySimplificado.Models.Enum;
using PicPaySimplificado.Repositories;
using PicPaySimplificado.Services.Dtos;
using PicPaySimplificado.Utils;

namespace PicPaySimplificado.Services;

public class TransacaoService
{
    private readonly TransacaoRepository _transacaoRepository;
    private readonly CarteiraRepository _carteiraRepository;
    private readonly EncontrarCarteira _encontrarCarteira;

    public TransacaoService(TransacaoRepository transacaoRepository, CarteiraRepository carteiraRepository, EncontrarCarteira encontrarCarteira)
    {
        _carteiraRepository = carteiraRepository;
        _transacaoRepository = transacaoRepository;
        _encontrarCarteira = encontrarCarteira;
    }
    public async Task<string> CriarTransacao(CriarTransacaoDto data)
    {
        try
        {   
            CarteiraEntity? carteiraEncontrada = await _encontrarCarteira.execute(data.recebedor, data.recebedorType);
            if (carteiraEncontrada == null) return "Usuário não encontrado!";
            
            TransacaoRequest request = new TransacaoRequest(
                data.tipoTransacao,
                data.valor,
                carteiraEncontrada.Id,
                data.idPagador,
                DateTime.Now,
                TransacaoStatusTypeEntity.EMPROCESSO
            );
            TransacaoEntity transacao = await _transacaoRepository.CriarTransacao(request);
            await _transacaoRepository.CommitAsync();
            return await ProcessarTransacao(transacao);
        }
        catch (Exception)
        {
            throw;
        }
    }

public async Task<string> ProcessarTransacao(TransacaoEntity data)
{
    try
    {
        if (data.TransacaoStatus != TransacaoStatusTypeEntity.EMPROCESSO)
            return "Esta transação já foi processada!";

        ProcessarTransacaoRequest request = new ProcessarTransacaoRequest(data.IdPagador, data.IdRecebedor, data.Valor);

        if (data.TipoTransacao == TransacaoTypeEntity.CREDITO)
        {
            var resultProcessarCredito = await _carteiraRepository.ProcessarCredito(request);
            if (resultProcessarCredito == "Sucesso!")
            {
                data.TransacaoStatus = TransacaoStatusTypeEntity.FINALIZANDA;
                var resultUpdateTransacao = await _transacaoRepository.UpdateTransacao(data);
                if (resultUpdateTransacao == "Sucesso!")
                {
                    await _carteiraRepository.CommitAsync();
                    await _transacaoRepository.CommitAsync();
                    return "Sucesso!";
                }
                else
                {
                    return "Erro ao atualizar transação!";
                }
            }
            else
            {
                return $"Erro ao processar crédito: {resultProcessarCredito}";
            }
        }
        else
        {
            var resultProcessarSaldo = await _carteiraRepository.ProcessarSaldo(request);
            if (resultProcessarSaldo == "Sucesso!")
            {
                data.TransacaoStatus = TransacaoStatusTypeEntity.FINALIZANDA;
                var resultUpdateTransacao = await _transacaoRepository.UpdateTransacao(data);
                if (resultUpdateTransacao == "Sucesso!")
                {
                    await _carteiraRepository.CommitAsync();
                    await _transacaoRepository.CommitAsync();
                    return "Sucesso!";
                }
                else
                {
                    return "Erro ao atualizar transação!";
                }
            }
            else
            {
                return $"Erro ao processar saldo: {resultProcessarSaldo}";
            }
        }
    }
    catch (Exception ex)
    {
        return $"Erro inesperado: {ex.Message}";
    }
}

}