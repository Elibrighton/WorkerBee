using System;
using System.Collections.Generic;
using System.Text;
using WorkerBee.Base;
using WorkerBee.Models;

namespace WorkerBee.ViewModels
{
    public class DashboardViewModel : ObservableObject, IDashboadViewModel
    {
        private IDashboardModel _dashboardModel;

        public DashboardViewModel(IDashboardModel dashboardModel)
        {
            _dashboardModel = dashboardModel;
        }

        public string TestLabel
        {
            get { return _dashboardModel.TestLabel; }
            set
            {
                _dashboardModel.TestLabel = value;
                NotifyPropertyChanged("TestLabel");
            }
        }
    }
}
