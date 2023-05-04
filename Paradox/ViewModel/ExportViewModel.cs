using Commands;
using Interfaces;
using Paradox.Models;
using Stimulsoft.Report;
using System.IO;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ExportPdfViewModel : NotifyPropertyChangedModel
    {
        private Command _exportCommand;
        private Command _openDocumentCommand;
        private readonly IExport _exportService;
        private readonly IOpenDocument _openDocumentService;
        private bool _isBusy;
        public ExportFile ExportFile { get; set; } = new() { ExportType = StiExportFormat.Pdf };
        public Command OpenDocumentCommand
        {
            get
            {
                return _openDocumentCommand ??= new Command(async () =>
                await _openDocumentService.OpenDocument(ExportFile.ExportFilePath),
                () => ExportFile.IsExported);
            }
        }
        public Command ExportCommand
        {
            get
            {
                return _exportCommand ??= new Command(async () => await ExportJsonToPdf(), () => !IsBusy);
            }
        }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
                ExportCommand.RaiseCanExecuteChanged();
                OpenDocumentCommand.RaiseCanExecuteChanged();
            }
        }

        public ExportPdfViewModel(IExport exportService, IOpenDocument openDocumentService)
        {
            _exportService = exportService;
            _openDocumentService = openDocumentService;
        }

        public async Task ExportJsonToPdf()
        {
            IsBusy = true;
            await _exportService.Export(ExportFile);
            IsBusy = false;
        }
    }
}
