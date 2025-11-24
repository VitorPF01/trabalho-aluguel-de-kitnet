
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionar serviços para a camada Application e Injeção de Dependência
        }
    }
}
