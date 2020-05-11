using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using WorkerBee.DAL;

namespace WorkerBee.Models
{
    public class WorkItemsModel : IWorkItemsModel
    {
        public ObservableCollection<IWorkItem> WorkItemsListBoxItemSource { get; set; }
        public IWorkItem SelectedWorkItemsListBoxItem { get; set; }
        public bool IsIncludeCompletedCheckboxChecked { get; set; }
        public DateTime SelectedWorkItemDate { get; set; }

        public WorkItemsModel()
        {
            SelectedWorkItemDate = DateTime.Now;
            WorkItemsListBoxItemSource = ReadAll();
        }

        public ObservableCollection<IWorkItem> ReadAll()
        {
            var workItems = new ObservableCollection<IWorkItem>();

            using (var db = new WorkerBeeContext())
            {
                workItems = new ObservableCollection<IWorkItem>(db.WorkItems
                    .Where(wi => (IsIncludeCompletedCheckboxChecked || wi.Completed == IsIncludeCompletedCheckboxChecked)
                     && wi.Date.Date == SelectedWorkItemDate.Date)
                    .OrderBy(wi => wi.Id));
            }

            return workItems;
        }

        public void Read()
        {
            using (var db = new WorkerBeeContext())
            {
                var workItem = db.WorkItems
                    .OrderBy(wi => wi.Id)
                    .First();
            }
        }

        public void Update()
        {
            using (var db = new WorkerBeeContext())
            {
                var workItem = db.WorkItems
                    .OrderBy(wi => wi.Id)
                    .First();

                workItem.Description = "Update WorkerBee app";
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            using (var db = new WorkerBeeContext())
            {
                db.Remove(SelectedWorkItemsListBoxItem);
                db.SaveChanges();
            }
        }

        public void MarkAsCompleted()
        {
            using (var db = new WorkerBeeContext())
            {
                var workItem = db.WorkItems
                    .Where(wi => wi.Id == SelectedWorkItemsListBoxItem.Id)
                    .First();

                workItem.Completed = true;
                db.SaveChanges();
            }
        }
    }
}
