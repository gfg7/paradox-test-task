using Paradox.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IExport
    {
        Task Export(ExportFile exportFile);
    }
}
