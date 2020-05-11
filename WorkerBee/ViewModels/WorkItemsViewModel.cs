using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WorkerBee.Base;
using WorkerBee.DAL;
using WorkerBee.Models;
using WorkerBee.Views;

namespace WorkerBee.ViewModels
{
    public class WorkItemsViewModel : ObservableObject, IWorkItemsViewModel
    {
        private IWorkItemsModel _workItemsModel;

        public WorkItemsViewModel(IWorkItemsModel workItemsModel)
        {
            _workItemsModel = workItemsModel;

            DeleteButtonCommand = new RelayCommand(OnDeleteButtonCommand);
            CompleteButtonCommand = new RelayCommand(OnCompleteButtonCommand);
            IncludeCompletedCheckboxCheckedCommand = new RelayCommand(OnIncludeCompleteButtonCommand);
            SelectedWorkItemDateChangedCommand = new RelayCommand(OnSelectedWorkItemDateChangedCommand);
            AddButtonCommand = new RelayCommand(OnAddButtonCommand);

        }

        public ICommand DeleteButtonCommand { get; set; }
        public ICommand CompleteButtonCommand { get; set; }
        public ICommand IncludeCompletedCheckboxCheckedCommand { get; set; }
        public ICommand SelectedWorkItemDateChangedCommand { get; set; }
        public ICommand AddButtonCommand { get; set; }

        public ObservableCollection<IWorkItem> WorkItemsListBoxItemSource
        {
            get { return _workItemsModel.WorkItemsListBoxItemSource; }
            set
            {
                _workItemsModel.WorkItemsListBoxItemSource = value;
                NotifyPropertyChanged("WorkItemsListBoxItemSource");
            }
        }

        public IWorkItem SelectedWorkItemsListBoxItem
        {
            get { return _workItemsModel.SelectedWorkItemsListBoxItem; }
            set
            {
                _workItemsModel.SelectedWorkItemsListBoxItem = value;
                NotifyPropertyChanged("SelectedWorkItemsListBoxItem");
            }
        }

        public bool IsIncludeCompletedCheckboxChecked
        {
            get { return _workItemsModel.IsIncludeCompletedCheckboxChecked; }
            set
            {
                if (_workItemsModel.IsIncludeCompletedCheckboxChecked != value)
                {
                    _workItemsModel.IsIncludeCompletedCheckboxChecked = value;
                    NotifyPropertyChanged("IsIncludeCompletedCheckboxChecked");
                }
            }
        }

        public DateTime SelectedWorkItemDate
        {
            get { return _workItemsModel.SelectedWorkItemDate; }
            set
            {
                if (_workItemsModel.SelectedWorkItemDate != value)
                {
                    _workItemsModel.SelectedWorkItemDate = value;
                    NotifyPropertyChanged("SelectedWorkItemDate");
                }
            }
        }

        private void OnDeleteButtonCommand(object param)
        {
            if (SelectedWorkItemsListBoxItem != null)
            {
                _workItemsModel.Delete();

                WorkItemsListBoxItemSource = _workItemsModel.ReadAll();
            }
        }

        private void OnCompleteButtonCommand(object param)
        {
            if (SelectedWorkItemsListBoxItem != null)
            {
                _workItemsModel.MarkAsCompleted();

                WorkItemsListBoxItemSource = _workItemsModel.ReadAll();
            }
        }

        private void OnIncludeCompleteButtonCommand(object param)
        {
            WorkItemsListBoxItemSource = _workItemsModel.ReadAll();
        }

        private void OnSelectedWorkItemDateChangedCommand(object param)
        {
            WorkItemsListBoxItemSource = _workItemsModel.ReadAll();
        }

        private void OnAddButtonCommand(object param)
        {
            var addWorkItemModel = new AddWorkItemModel
            {
                SelectedWorkItemDate = SelectedWorkItemDate
            };
            var addWorkItemViewModel = new AddWorkItemViewModel(addWorkItemModel);
            var addWorkItemView = new AddWorkItemView
            {
                DataContext = addWorkItemViewModel
            };
            addWorkItemView.ShowDialog();
        }
    }
}
