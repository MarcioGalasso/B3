using Prova.B3.Domain.Entities;
using Prova.B3.Repository.Interfaces;

namespace Prova.B3.Api;

public class DataBaseStart : IHostedService
{
    private readonly IServiceProvider serviceProvider;

    public DataBaseStart(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {

        using (var scoped = serviceProvider.CreateScope())
        {
            var repository = scoped.ServiceProvider.GetRequiredService<ITaxasRepository>();
            var taxasMock = new List<Taxas> {
                                    new Taxas { Id = Guid.NewGuid() ,Cdi =  1,Tb = 110 ,DataDesativacao = DateTime.Now, Meses = 2, Impostos= 10M},
                                    new Taxas { Id = Guid.NewGuid() ,Cdi =  0.009M,Tb = 1.08M, Meses=6,Impostos = 0.225M },
                                    new Taxas { Id = Guid.NewGuid() ,Cdi =  0.009M,Tb = 1.08M, Meses=12,Impostos = 0.20M },
                                    new Taxas { Id = Guid.NewGuid() ,Cdi =  0.009M,Tb = 1.08M, Meses=24,Impostos = 0.175M },
                                    new Taxas { Id = Guid.NewGuid() ,Cdi =  0.009M,Tb = 1.08M, Meses=0,Impostos = 0.15M },
                                };
            await repository.PostAsync(taxasMock);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
