using Stimulsoft.Report;
using System.ComponentModel;
using System.IO;

namespace Paradox.Models
{
    public class ExportFile : NotifyPropertyChangedModel, IDataErrorInfo
    {
        private string _originalFilePath;
        private string _exportFilePath;
        private StiExportFormat _exportType;
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = string.Empty;
                switch (columnName)
                {
                    case nameof(OriginalFilePath):
                        if (!File.Exists(OriginalFilePath) && OriginalFilePath is not null)
                        {
                            _error = "Файл не существует или путь не верен";
                        }
                        break;
                    case nameof(ExportFilePath):
                        if (ExportFilePath is not null)
                        {
                            if (Path.GetExtension(ExportFilePath) != ".pdf")
                            {
                                _error = "Неверное расширение файла\n";
                            }

                            if (!Directory.Exists(Path.GetDirectoryName(ExportFilePath)))
                            {
                                _error += "Директория не существует или путь не верен";
                            }
                        }
                        break;
                }

                OnPropertyChanged(nameof(Error));

                return _error;
            }
        }

        public string OriginalFilePath
        {
            get => _originalFilePath;
            set
            {
                _originalFilePath = value;
                OnPropertyChanged();
            }
        }
        public string ExportFilePath
        {
            get => _exportFilePath;
            set
            {
                _exportFilePath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsExported));
            }
        }
        public StiExportFormat ExportType { get => _exportType; set => _exportType = value; }

        public string Error => _error;
        public bool IsExported => File.Exists(ExportFilePath);
    }
}
