using Interfaces;
using Paradox.Models;
using Stimulsoft.Report;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class ExportJsonService : IExport
    {
        private StiReport? _report;
        public async Task Export(ExportFile exportFile)
        {
            var jsonReport = await File.ReadAllTextAsync(exportFile.OriginalFilePath);
            using (_report = new StiReport())
            {
                _report.LoadDocumentFromJson(jsonReport);
                await _report.ExportDocumentAsync(exportFile.ExportType, exportFile.ExportFilePath);
            }
        }
    }
}
