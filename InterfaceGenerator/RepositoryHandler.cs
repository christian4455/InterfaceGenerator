using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InterfaceGenerator.Types;
using InterfaceGenerator.Utils;

using InterfaceGenerator.Utils.Logger;

namespace InterfaceGenerator
{
    public class RepositoryHandler : IRepositoryHandler
    {

        private Types.InterfaceData m_Data = new Types.InterfaceData();
        private EA.Repository m_InterfaceOfInterest = null;

        public RepositoryHandler()
        {
            /* Intentionally left blank */
        }

        List<Types.InterfaceData> IRepositoryHandler.HandleRepository(EA.Repository interfaceElement)
        {
            List<Types.InterfaceData> list = new List<Types.InterfaceData>();

            m_InterfaceOfInterest = interfaceElement;

            FetchNamespace(interfaceElement);

            foreach (EA.Element e in interfaceElement.GetTreeSelectedPackage().Elements)
            {
                if (EnumUtil.ParseEnum<ElementType>(e.Type, ElementType.Unknown) == ElementType.Interface)
                {
                    m_Data = new Types.InterfaceData();

                    m_Data.SetInterfaceName(e.Name);

                    HandleInterface(e);

                    list.Add(m_Data);
                }
            }

            return list;
        }

        private void FetchNamespace(EA.Repository interfaceElement)
        {
            EA.Package package = interfaceElement.GetTreeSelectedPackage();

            while (!package.IsNamespace)
            {
                m_Data.AddNamespaceElement(package.Name);
                package = interfaceElement.GetPackageByID(package.ParentID);
            }
        }

        private string FetchNamespace(EA.Element datatype)
        {
            string result = "";

            EA.Package package = m_InterfaceOfInterest.GetPackageByID(datatype.PackageID);

            result += "::" + datatype.Name;

            while (!package.IsNamespace)
            {
                result = "::" + package.Name + result;
                package = m_InterfaceOfInterest.GetPackageByID(package.ParentID);
            }

            return result;
        }

        private void HandleInterface(EA.Element interfaceElement)
        {
            foreach (EA.Method m in interfaceElement.Methods)
            {
                HandleMethod(m);
            }
        }

        private void HandleMethod(EA.Method method)
        {
            string returnType = method.ReturnType;

            Method m = new Method(method.Name, returnType);

            foreach (EA.Parameter p in method.Parameters)
            {
                HandleParameter(p, m);
            }

            m_Data.AddMethod(m);
        }

        private void HandleParameter(EA.Parameter param, Method method)
        {
            Parameter p = new Parameter();
            p.SetName(param.Name);
            Int32 id = Int32.Parse(param.ClassifierID);
            EA.Element datatype = m_InterfaceOfInterest.GetElementByID(id);
            p.SetDatatype(FetchNamespace(datatype));
            p.SetIsConst(param.IsConst);
            p.SetPositionInArgList(param.Position);

            method.AddParameter(p);
        }
    }
}
