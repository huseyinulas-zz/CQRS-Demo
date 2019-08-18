using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Materializer
{
    public class MassTransitBusControlService : IHostedService
    {
        private readonly IBusControl busControl;

        public MassTransitBusControlService(IBusControl busControl)
        {
            this.busControl = busControl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await busControl.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await busControl.StopAsync(cancellationToken);
        }
    }
}
