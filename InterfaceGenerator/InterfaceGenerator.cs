using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using InterfaceGenerator.Types;

namespace InterfaceGenerator
{
    public class InterfaceGenerator : IPlugin
    {
        private string DEFAULT_TARGETPATH = "D:\\";

        IRepositoryHandler m_RepositoryHandler = null;
        IInterfaceBuilder m_InterfaceBuilder = null;
        IFileWriter m_IFileWriter = null;

        public InterfaceGenerator()
        {
            /* Intentionally left blank */
        }
        
        void IPlugin.ProcessRepository(EA.Repository repository)
        {
            string targetPath = GetTargetPath();

            List<InterfaceData> data = m_RepositoryHandler.HandleRepository(repository);

            List<Types.Product> products = new List<Types.Product>();

            foreach (InterfaceData d in data)
            {
                products.Add(m_InterfaceBuilder.CreateProduct(d, d.GetInferfaceName() + ".hpp"));
            }

            foreach (Types.Product p in products)
            {
                m_IFileWriter.WriteProduct(targetPath, p);
            }

            MessageBox.Show("Finish");
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

        private string GetTargetPath()
        {
            string result = DEFAULT_TARGETPATH;

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                result = folderDialog.SelectedPath + "\\";
            }

            return result;
        }
    }
}
