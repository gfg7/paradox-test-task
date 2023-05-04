using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pages;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace Paradox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public App()
        {
            _host = Host.CreateDefaultBuilder()
            .ConfigureServices((services) =>
            {
                services.AddScoped<IExport, ExportJsonService>();
                services.AddScoped<IOpenDocument, OpenPdfService>();
                services.AddScoped<ExportPdfViewModel>();
                services.AddScoped<StimulsoftExport>();
                services.AddSingleton<MainAppWindow>();
            })
            .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            var mainWindow = _host.Services.GetRequiredService<MainAppWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
