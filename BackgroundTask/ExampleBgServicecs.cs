
namespace BackgroundTask
{
    public class ExampleBgServiec : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           // while (!stoppingToken.IsCancellationRequested) 
            {
                Console.WriteLine("Ping");
               // await Task.Delay(1000);
            }
        }
    }
}
