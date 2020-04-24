using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerBee.Models
{
    public class DashboardModel : IDashboardModel
    {
        public string TestLabel { get; set; }

        public DashboardModel()
        {
            TestLabel = "TestLabel";
        }
    }
}
