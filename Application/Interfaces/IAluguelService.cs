using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Application.Interfaces;

public interface IAluguelService
{
    Task<Aluguel> CriarAluguel(NovoAluguelRequest request);
}
