using Teste.Branef.Repository.Context;

namespace Teste.Branef.Repository.Interfaces
{
    public interface IContextManager
    {
        TesteBanefContext GetContext();
        string GetConnectionString { get; }
    }
}
