using bicicletario.Application.Interfaces;
using bicicletario.WebAPI.Controllers;
using Moq;

namespace bicicletario.Tests;

public class TrancaControllerTests
{
    private readonly Mock<ITrancaService> _trancaServiceMock;
    private readonly TrancaController _trancaController;
    
    public TrancaControllerTests()
    {
        _trancaServiceMock = new Mock<ITrancaService>();
        _trancaController = new TrancaController(_trancaServiceMock.Object);
    }
    
    
}
