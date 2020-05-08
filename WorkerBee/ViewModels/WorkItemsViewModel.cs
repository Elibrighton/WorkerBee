using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WorkerBee.Base;
using WorkerBee.DAL;
using WorkerBee.Models;

namespace WorkerBee.ViewModels
{
    public class WorkItemsViewModel : ObservableObject, IWorkItemsViewModel
    {
        private IWorkItemsModel _workItemsModel;

        public WorkItemsViewModel(IWorkItemsModel workItemsModel)
        {
            _workItemsModel = workItemsModel;

            SaveButtonCommand = new RelayCommand(OnSaveButtonCommand);
            DeleteButtonCommand = new RelayCommand(OnDeleteButtonCommand);
        }

        public ICommand SaveButtonCommand { get; set; }
        public ICommand DeleteButtonCommand { get; set; }

        public string AddWorkItemTextBoxText
        {
            get { return _workItemsModel.AddWorkItemTextBoxText; }
            set
            {
                _workItemsModel.AddWorkItemTextBoxText = value;
                NotifyPropertyChanged("AddWorkItemTextBoxText");
            }
        }
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

        private void OnSaveButtonCommand(object param)
        {
            if (!string.IsNullOrEmpty(AddWorkItemTextBoxText))
            {
                _workItemsModel.Create();

                WorkItemsListBoxItemSource = _workItemsModel.ReadAll();
                AddWorkItemTextBoxText = string.Empty;
            }
            else
            {
                MessageBox.Show("A description is required.");
            }
        }

        private void OnDeleteButtonCommand(object param)
        {
            if (SelectedWorkItemsListBoxItem != null)
            {
                _workItemsModel.Delete();

                WorkItemsListBoxItemSource = _workItemsModel.ReadAll();
            }
            else
            {
                MessageBox.Show("Item selection is required.");
            }
        }
    }
}
