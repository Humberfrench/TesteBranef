using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Teste.Branef.Repository.Interfaces;


namespace Teste.Branef.Repository.Context
{
    public class ContextManager(IHttpContextAccessor context, IConfiguration configuration) : IContextManager
    {
        private const string CONTEXT_KEY = "ContextManager.Context";
        private readonly IHttpContextAccessor context = context;
        private readonly IConfiguration configuration = configuration;

        public string GetConnectionString => configuration.GetConnectionString("branefContext") ?? "";

        public TesteBanefContext GetContext()
        {
            if (context.HttpContext == null)
                return new TesteBanefContext();

            if (context.HttpContext.Items[CONTEXT_KEY] == null)
            {
                context.HttpContext.Items.Add(CONTEXT_KEY, new TesteBanefContext());
            }

            return context.HttpContext.Items[CONTEXT_KEY] as TesteBanefContext ?? new TesteBanefContext();
        }

    }
}
