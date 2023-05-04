using Stimulsoft.Report;
using System.ComponentModel;
using System.IO;

namespace Paradox.Models
{
    public class ExportFile : NotifyPropertyChangedModel, IDataErrorInfo
    {
        private string originalFilePath;
        private string exportFilePath;
        private StiExportFormat exportType;
        private string error;

        public string this[string columnName]
        {
            get
            {
                error = string.Empty;
                switch (columnName)
                {
                    case nameof(OriginalFilePath):
                        if (!File.Exists(OriginalFilePath) && OriginalFilePath is not null)
                        {
                            error = "Файл не существует или путь не верен";
                        }
                        break;
                    case nameof(ExportFilePath):
                        if (ExportFilePath is not null)
                        {
                            if (Path.GetExtension(ExportFilePath) != ".pdf")
                            {
                                error = "Неверное расширение файла\n";
                            }

                            if (!Directory.Exists(Path.GetDirectoryName(ExportFilePath)))
                            {
                                error += "Директория не существует или путь не верен";
                            }
                        }
                        break;
                }

                OnPropertyChanged(nameof(Error));

                return error;
            }
        }

        public string OriginalFilePath
        {
            get => originalFilePath;
            set
            {
                originalFilePath = value;
                OnPropertyChanged();
            }
        }
        public string ExportFilePath
        {
            get => exportFilePath;
            set
            {
                exportFilePath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsExported));
            }
        }
        public StiExportFormat ExportType { get => exportType; set => exportType = value; }

        public string Error => error;
        public bool IsExported => File.Exists(ExportFilePath);
    }
}
