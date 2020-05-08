using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerBee.DAL
{
    public interface IWorkItem
    {
        int Id { get; set; }
        string Description { get; set; }
    }
}
