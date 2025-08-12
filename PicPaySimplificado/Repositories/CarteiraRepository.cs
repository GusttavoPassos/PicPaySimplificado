using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Infra;
using PicPaySimplificado.Models;
using PicPaySimplificado.Repositories.Dtos;

namespace PicPaySimplificado.Repositories;

public class CarteiraRepository : CarteiraRepositoryDto
{
    private readonly AppDbContext _context;

    public CarteiraRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Task CreateCarteira(CarteiraEntity carteira)
    {
        try
        {
            _context.Carteiras.Add(carteira);
            return Task.CompletedTask;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task UpdateCarteira(CarteiraEntity carteira)
    {
        try
        {
            _context.Carteiras.Update(carteira);
            return Task.CompletedTask;
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    public async Task<CarteiraEntity?> GetCarteiraById(Guid id)
    {
        try
        {
            var carteira = await _context.Carteiras.FindAsync(id);
            return carteira;
        }
        catch (Exception)
        {
            throw;
        }
    }

    
    public async Task<CarteiraEntity?> GetCarteiraByCpfCnpj(string cpfCnpj)
    {
        try
        {
            var carteira = await _context.Carteiras.FirstOrDefaultAsync(c => c.CPFCNPJ == cpfCnpj);
            return carteira;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CarteiraEntity?> GetCarteiraByEmail(string email)
    {
        try
        {
            var carteira = await _context.Carteiras.FirstOrDefaultAsync(c => c.Email == email);
            return carteira;
        }
        catch (Exception)
        { 
            throw;
        }
    }

    public async Task<CarteiraEntity?> GetCarteiraByTelefone(string telefone)
    {
        try
        {
            var carteira = await _context.Carteiras.FirstOrDefaultAsync(c => c.Telefone == telefone);
            return carteira;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> ProcessarSaldo(ProcessarTransacaoRequest request)
    {
        try
        {
            CarteiraEntity pagadorData = await _context.Carteiras.FindAsync(request.pagador);
            CarteiraEntity recebedorData = await _context.Carteiras.FindAsync(request.recebedor);
            
            if(pagadorData.Saldo < request.valor) return "Saldo Insuficiente!";
            
            pagadorData.Saldo -= request.valor;
            recebedorData.Saldo += request.valor;
            
            _context.Carteiras.Update(pagadorData);
            _context.Carteiras.Update(recebedorData);
            
            return "Sucesso!";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> ProcessarCredito(ProcessarTransacaoRequest request)
    {
        try
        {
            CarteiraEntity pagadorData = await _context.Carteiras.FindAsync(request.pagador);
            CarteiraEntity recebedorData = await _context.Carteiras.FindAsync(request.recebedor);
            
            if(pagadorData.Limite < request.valor) return "Limite Insuficiente!";
            
            pagadorData.Limite -= request.valor;
            recebedorData.Saldo += request.valor;
            
            _context.Carteiras.Update(pagadorData);
            _context.Carteiras.Update(recebedorData);
            
            return "Sucesso!";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CommitAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}