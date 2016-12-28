using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceGenerator.Types;

namespace InterfaceGenerator
{
    class InterfaceBuilder : IInterfaceBuilder
    {
        private string ELSE = "else";
        private string NONE = "";

        public Product CreateProduct(InterfaceData data, string filename)
        {
            Product product = new Product();

            product.SetFilename(filename);

            product.Append(CreateHeader(data.GetNamespaces(), filename));
            product.Append(CreateBody(data.GetMethods()));
            product.Append(CreateFooter(data.GetNamespaces(), filename));

            return product;
        }

        private string CreateHeader(List<string> namespaces, string filename)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("#ifndef " + ConvertToClassname(filename).ToUpper() +"_HPP");
            result.AppendLine("#define " + ConvertToClassname(filename).ToUpper() + "_HPP");
            result.AppendLine("");

            namespaces.Reverse();

            foreach (string nSpace in namespaces)
            {
                result.AppendLine("namespace " + nSpace + " {");
            }

            if (namespaces.Count > 0)
            {
                result.AppendLine("");
            }

            result.AppendLine("class " + ConvertToClassname(filename));
            result.AppendLine("{");
            result.AppendLine("");
            result.AppendLine("public:");
            result.AppendLine("");
            result.AppendLine("    " + ConvertToClassname(filename) + "() {}");
            result.AppendLine("    virtual ~"+ ConvertToClassname(filename) + "() {}");
            result.AppendLine("");

            return result.ToString();
        }

        private string CreateBody(List<Method> methods)
        {
            StringBuilder result = new StringBuilder();

            foreach(Method m in methods)
            {
                if (IsLegalFunctionName(m.GetFunctionName()))
                {
                    result.Append("    virtual " + m.GetReturnType() + " " + m.GetFunctionName() + "(");

                    foreach (Parameter p in m.GetParameter())
                    {
                        if (p.IsConst())
                        {
                            result.Append("const ");
                        }

                        result.Append(p.GetDatatype() + " ");

                        result.Append(p.GetName());

                        if(m.GetParameter().IndexOf(p) != m.GetParameter().Count - 1)
                        {
                            result.Append(", ");
                        }
                    }

                    result.AppendLine(") = 0;");

                    result.AppendLine("");
                }
            }

            return result.ToString();
        }

        private string CreateFooter(List<string> namespaces, string filename)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("private:");
            result.AppendLine("    /// @brief Automatically generated forbidden copy-constructor");
            result.AppendLine("    " + ConvertToClassname(filename) + "(const " + ConvertToClassname(filename) + "&)");
            result.AppendLine("    {");
            result.AppendLine("    }");
            result.AppendLine("");
            result.AppendLine("    /// @brief Automatically generated forbidden assignment operator");
            result.AppendLine("    " + ConvertToClassname(filename) + "& operator =(const " + ConvertToClassname(filename) + "&)");
            result.AppendLine("    {");
            result.AppendLine("        return *this;");
            result.AppendLine("    }");
            result.AppendLine("};");
            result.AppendLine("");

            namespaces.Reverse();
            foreach (string nSpace in namespaces)
            {
                result.AppendLine("} // namespace - " + nSpace);
            }

            if (namespaces.Count > 0)
            {
                result.AppendLine("");
            }

            result.AppendLine("#endif // !" + ConvertToClassname(filename).ToUpper() + "_HPP");

            return result.ToString();
        }

        private string ConvertToClassname(string filename)
        {
            string result = "";

            result = filename.Remove(filename.IndexOf("."));

            return result;
        }

        private bool IsLegalFunctionName(string functionName)
        {
            bool result = false;

            if (functionName != ELSE && functionName != NONE)
            {
                result = true;
            }

            return result;
        }
    }
}
