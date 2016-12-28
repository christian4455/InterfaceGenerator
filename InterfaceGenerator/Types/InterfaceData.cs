using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceGenerator.Types
{
    public class InterfaceData
    {
        private string m_InterfaceName;
        private List<Method> m_Methods = new List<Method>();
        private string m_Namespace = "";
        private List<string> m_Namespaces = new List<string>();

        public InterfaceData()
        {
            /* Intentionally left blank */
        }

        public void SetInterfaceName(string interfaceName)
        {
            m_InterfaceName = interfaceName;
        }

        public string GetInferfaceName()
        {
            return m_InterfaceName;
        }

        public void AddMethod(Method method)
        {
            m_Methods.Add(method);
        }

        public void AddNamespaceElement(string namespaceElement)
        {
            m_Namespaces.Add(namespaceElement);

            if (m_Namespace.Length > 0)
            {
                m_Namespace = namespaceElement + "::" + m_Namespace;
            }
            else
            {
                m_Namespace = namespaceElement;
            }
        }

        public string GetNamespace()
        {
            return m_Namespace;
        }

        public List<string> GetNamespaces()
        {
            return m_Namespaces;
        }

        public List<Method> GetMethods()
        {
            return m_Methods;
        }
    }
}
