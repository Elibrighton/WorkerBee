using System;
using System.Collections.Generic;
using System.Text;
using WorkerBee.DAL;

namespace WorkerBee.Models
{
    public class AddWorkItemModel: IAddWorkItemModel
    {
        public string AddWorkItemTextBoxText { get; set; }
        public DateTime SelectedWorkItemDate { get; set; }

        public void Create()
        {
            using (var db = new WorkerBeeContext())
            {
                db.Add(new WorkItem { Description = AddWorkItemTextBoxText, Date = SelectedWorkItemDate });
                db.SaveChanges();
            }
        }
    }
}
