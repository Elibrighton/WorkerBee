using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerBee.Models
{
    public interface IAddWorkItemModel
    {
        string AddWorkItemTextBoxText { get; set; }
        DateTime SelectedWorkItemDate { get; set; }

        void Create();
    }
}
