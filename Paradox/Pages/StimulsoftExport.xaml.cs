using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace Pages
{
    /// <summary>
    /// Логика взаимодействия для StimulsoftExport.xaml
    /// </summary>
    public partial class StimulsoftExport : Page
    {
        private readonly OpenFileDialog _openFileDialog = new()
        {
            Filter = "json|*.json;"
        };

        private readonly SaveFileDialog _saveFileDialog = new()
        {
            OverwritePrompt= true,
            AddExtension= true,
            Filter = "pdf|*.pdf",
            CreatePrompt= true
        };

        public StimulsoftExport(ExportPdfViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void FileExplorer_Click(object sender, RoutedEventArgs e)
        {
            _openFileDialog.ShowDialog();
            OriginalFilePathInput.Text = _openFileDialog.FileName;
        }

        private void DirectoryExplorer_Click(object sender, RoutedEventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == true)
            {
                ExportFilePathInput.Text = _saveFileDialog.FileName;
            }
        }
    }
}
