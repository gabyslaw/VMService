using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConsumer.Services
{
    public interface IVMService
    {
        string Create();
        string GetStatus(string requestId);
    }
}
