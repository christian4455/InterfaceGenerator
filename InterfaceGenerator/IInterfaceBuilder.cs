using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceGenerator.Types;

namespace InterfaceGenerator
{
    public interface IInterfaceBuilder
    {
        Product CreateProduct(InterfaceData data, string filename);
    }
}
