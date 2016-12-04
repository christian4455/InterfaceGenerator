using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceGenerator
{
    public interface IPlugin
    {
        void ProcessRepository(EA.Repository repository);
    }
}
