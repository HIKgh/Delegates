using Application.Interfaces;

namespace Application.Implementations;

public class GetFileNameProvider : IGetFileNameProvider
{
    public event EventHandler<FileArgs>? FileFound;

    public void OnGetFileName(string directory)
    {
        if (Directory.Exists(directory))
        {
            var files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                FileFound?.Invoke(this, new FileArgs(file));
            }
        }
    }
}