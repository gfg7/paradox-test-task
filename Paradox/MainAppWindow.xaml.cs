using Microsoft.Extensions.DependencyInjection;
using Pages;
using System;
using System.Windows;

namespace Paradox
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainAppWindow : Window
    {
        public MainAppWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            var exportPage = serviceProvider.GetRequiredService<StimulsoftExport>();
            Frame.Navigate(exportPage);
        }
    }
}
