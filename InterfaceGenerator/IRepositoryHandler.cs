using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Types;

namespace InterfaceGenerator
{
    public interface IRepositoryHandler
    {
        Types.InterfaceData HandleRepository(EA.Repository interfaceElement);
    }
}
