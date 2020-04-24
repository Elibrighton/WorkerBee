using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WorkerBee.Models;
using WorkerBee.ViewModels;
using WorkerBee.Views;

namespace WorkerBee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDashboardModel, DashboardModel>();
            container.RegisterType<IDashboadViewModel, DashboardViewModel>();

            DashboardView dashboardView = container.Resolve<DashboardView>();
            dashboardView.Show();
        }
    }
}
