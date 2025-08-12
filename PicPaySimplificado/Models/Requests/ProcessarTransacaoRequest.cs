namespace PicPaySimplificado.Models;

public record ProcessarTransacaoRequest(Guid pagador, Guid recebedor, decimal valor);