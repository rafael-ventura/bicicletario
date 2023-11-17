using bicicletario.Domain.dtos;
using bicicletario.Domain.Models;

namespace bicicletario.Domain.Interfaces;

public interface IAluguelRepository
{
    Task<Aluguel> CriarAluguel(NovoAluguelRequest aluguel);
}
