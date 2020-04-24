using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using WorkerBee.ViewModels;

namespace WorkerBee.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        //[Dependency]
        //public DashboardViewModel ViewModel
        //{
        //    set { DataContext = value; }
        //}

        public DashboardView()
        {
            InitializeComponent();
        }
    }
}
