
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Prova.B3.Tests.Fixture
{

    public class ConfiguracaoServerFixture
    {
        public HttpClient Client { get; set; }
        public ConfiguracaoServerFixture()
        {
            CreateClient();
        }

        private void CreateClient()
        {
            var application = new WebApplicationFactory<Program>()
                                    .WithWebHostBuilder(builder =>
                                    {
                                        builder.ConfigureServices(services =>
                                        {
                                        });
                                    });

            Client = application.CreateClient();
        }
    }

}

