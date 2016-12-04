using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InterfaceGenerator.Types;
using InterfaceGenerator.Utils.Logger;

namespace InterfaceGenerator
{
    class FileWriter : IFileWriter
    {
        public FileWriter()
        {
            /* Intentionally left blank */
        }

        public void WriteProduct(string path, Product product)
        {
            Log.Info("");
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + product.GetFilename());
                file.WriteLine(product.GetProduct().ToString());
                file.Close();
            }
            catch (Exception e)
            {
                Log.Info("Exception:" + e.Message);
            }
            finally
            {
                // nothing
            }
        }
    }
}
