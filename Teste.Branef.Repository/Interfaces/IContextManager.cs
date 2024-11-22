using Teste.Branef.Repository.Context;

namespace Teste.Branef.Repository.Interfaces
{
    public interface IContextManager
    {
        TesteBranefContext GetContext();
        string GetConnectionString { get; }
    }
}
