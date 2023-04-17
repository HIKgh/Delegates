using Application;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Delegates;

static class Program
{
    private static void Main()
    {
        Console.Clear();
        var provider = DependencyInjection.ConfigureServices();
        var getMaxService = provider.GetRequiredService<IGetMaxEnumerableTestService>();
        getMaxService.Test();
        var getFileNameService = provider.GetRequiredService<IGetFileNameProviderTestService>();
        getFileNameService.Test();
    }
}