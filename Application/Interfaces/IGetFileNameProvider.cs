using Application.Implementations;

namespace Application.Interfaces;

public interface IGetFileNameProvider
{
    public event EventHandler<FileArgs>? FileFound;

    void OnGetFileName(string directory);
}