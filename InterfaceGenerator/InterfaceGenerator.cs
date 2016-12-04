using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceGenerator.Types;

namespace InterfaceGenerator
{
    public class InterfaceGenerator : IPlugin
    {
        IRepositoryHandler m_RepositoryHandler = null;
        IInterfaceBuilder m_InterfaceBuilder = null;
        IFileWriter m_IFileWriter = null;

        public InterfaceGenerator()
        {
            /* Intentionally left blank */
        }
        
        void IPlugin.ProcessRepository(EA.Repository repository)
        {
            InterfaceData data = m_RepositoryHandler.HandleRepository(repository);
        }

        public void SetRepositoryHandler(IRepositoryHandler repositoryHandler)
        {
            m_RepositoryHandler = repositoryHandler;
        }

        public void SetInterfaceBuilder(IInterfaceBuilder interfaceBuilder)
        {
            m_InterfaceBuilder = interfaceBuilder;
        }

        public void SetFileWriter(IFileWriter iFileWriter)
        {
            m_IFileWriter = iFileWriter;
        }
    }
}
