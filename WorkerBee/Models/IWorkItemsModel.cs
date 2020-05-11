using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkerBee.DAL;

namespace WorkerBee.Models
{
    public interface IWorkItemsModel
    {
        ObservableCollection<IWorkItem> WorkItemsListBoxItemSource { get; set; }
        IWorkItem SelectedWorkItemsListBoxItem { get; set; }
        bool IsIncludeCompletedCheckboxChecked { get; set; }
        DateTime SelectedWorkItemDate { get; set; }

        ObservableCollection<IWorkItem> ReadAll();
        void Delete();
        void MarkAsCompleted();
    }
}
