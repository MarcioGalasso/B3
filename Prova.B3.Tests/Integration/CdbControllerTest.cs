using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Prova.B3.Domain.Model;
using Prova.B3.Tests.Fixture;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Prova.B3.Tests.Integration
{
    public class CdbControllerTest : IClassFixture<ConfiguracaoServerFixture>
    {
        private readonly ConfiguracaoServerFixture configuracaoServer;

        public CdbControllerTest(ConfiguracaoServerFixture configuracaoServer)
        {
            this.configuracaoServer = configuracaoServer;
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, -100)]
        [InlineData(0, 200)]
        public async Task Parametro_InvalidosAsync(int mes, decimal valor)
        {
            var body = new Cdb { Meses = mes, Valor = valor };
            var content = JsonContent.Create(body);
            var result = await configuracaoServer.Client.PostAsync("cdb/calcular", content);
            result.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        [Theory]
        [MemberData(nameof(CdbControllerTest.CenariosParametroValidos), MemberType = typeof(CdbControllerTest))]

        public async Task Parametro_ValidosAsync(CdbCalc parametro)
        {
            var body = new Cdb { Meses = parametro.Meses, Valor = parametro.Valor };
            var content = JsonContent.Create(body);
            var result = await configuracaoServer.Client.PostAsync("cdb/calcular", content);
            result.Should().HaveStatusCode(HttpStatusCode.OK);
            var calculo = await result.Content.ReadFromJsonAsync<CdbCalc>();
            calculo.Imposto.Should().Be(parametro.Imposto);
            calculo.Liquido.Should().Be(parametro.Liquido);
            calculo.Bruto.Should().Be(parametro.Bruto);

        }

        public static IEnumerable<object[]> CenariosParametroValidos()
        {
            yield return new object[] { new CdbCalc { Meses = 1, Valor = 800, Imposto = 1.75M, Liquido = 7.78M, Bruto = 807.78M } };
            yield return new object[] { new CdbCalc { Meses = 7, Valor = 900, Imposto = 12.61M, Liquido = 63.05M, Bruto = 963.05M } };
            yield return new object[] { new CdbCalc { Meses = 13, Valor = 950, Imposto = 22.28M, Liquido = 127.3M, Bruto = 1077.3M } };
            yield return new object[] { new CdbCalc { Meses = 15, Valor = 1000, Imposto = 27.33M, Liquido = 156.15M, Bruto = 1156.15M } };
            yield return new object[] { new CdbCalc { Meses = 18, Valor = 1100, Imposto = 36.61M, Liquido = 209.21M, Bruto = 1309.21M } };
            yield return new object[] { new CdbCalc { Meses = 25, Valor = 1200, Imposto = 49.24M, Liquido = 328.29M, Bruto = 1528.29M } };

        }
    }
}
