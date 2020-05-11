using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerBee.DAL
{
    public class WorkItem : IWorkItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Date { get; set; }
    }
}
