using Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Services
{
    public class OpenPdfService : IOpenDocument
    {
        public Task OpenDocument(string path)
        {
            var process = new Process();
            process.StartInfo.FileName = path;
            process.EnableRaisingEvents= true;
            process.StartInfo.UseShellExecute= true;

            process.Exited += (sender, e) => process.Dispose();

            process.Start();

            return Task.CompletedTask;
        }
    }
}
