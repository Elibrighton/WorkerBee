using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Unity;
using WorkerBee.Base;
using WorkerBee.Models;
using WorkerBee.Views;

namespace WorkerBee.ViewModels
{
    public class DashboardViewModel : ObservableObject, IDashboadViewModel
    {
        private IDashboardModel _dashboardModel;

        public DashboardViewModel(IDashboardModel dashboardModel)
        {
            _dashboardModel = dashboardModel;

            WorkItemsButtonCommand = new RelayCommand(OnWorkItemsButtonCommand);
        }

        public ICommand WorkItemsButtonCommand { get; set; }

        public string TestLabel
        {
            get { return _dashboardModel.TestLabel; }
            set
            {
                _dashboardModel.TestLabel = value;
                NotifyPropertyChanged("TestLabel");
            }
        }

        private void OnWorkItemsButtonCommand(object param)
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IWorkItemsModel, WorkItemsModel>();
            //container.RegisterType<IWorkItemsViewModel, WorkItemsViewModel>();

            //var workItemsView = container.Resolve<WorkItemsView>();
            //workItemsView.Show();
            var workItemsModel = new WorkItemsModel();
            var workItemsViewModel = new WorkItemsViewModel(workItemsModel);
            var workItemsView = new WorkItemsView
            {
                DataContext = workItemsViewModel
            };
            workItemsView.Show();

        }
    }
}
