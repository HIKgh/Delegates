using Application.Interfaces;

namespace Application.Implementations;

public class GetFileNameProviderTestService : IGetFileNameProviderTestService
{
    private const string TestDirectory = "c:\\windows\\";
    private const string WinIniFile = "c:\\windows\\win.ini";

    private readonly IGetFileNameProvider _provider;
    private bool _found;

    public GetFileNameProviderTestService(IGetFileNameProvider provider)
    {
        _provider = provider;
    }

    public void Test()
    {
        Console.Clear();
        Console.WriteLine($"Поиск файлов в каталоге {TestDirectory}");
        _provider.FileFound += OnFileFoundEventHandler;
        _provider.OnGetFileName(TestDirectory);
        if (!_found)
        {
            _provider.FileFound -= OnFileFoundEventHandler;
        }
        Console.WriteLine("Нажмите любую клавишу ...");
        Console.ReadKey();
    }

    private void OnFileFoundEventHandler(object? sender, FileArgs e)
    {
        Console.WriteLine(e.FileName);
        if (e.FileName == WinIniFile)
        {
            _provider.FileFound -= OnFileFoundEventHandler;
            _found = true;
        }
    }
}