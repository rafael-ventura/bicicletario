namespace bicicletario.Domain.dtos;

public record IntegrarNaRedeRequest
{
    public int idTranca { get; set; }
    
    public int idBicicleta { get; set; }
    
    public int idFuncionario { get; set; }
}
