using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOpenDocument
    {
        Task OpenDocument(string path);
    }
}
