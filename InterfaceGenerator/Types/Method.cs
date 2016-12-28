using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceGenerator.Types
{
    public class Method
    {
        private string m_FunctionName;
        private string m_ReturnType;
        private List<Parameter> m_Parameter = new List<Parameter>();
        private bool m_IsStatic = false;

        public Method(string functionName, string returnType)
        {
            m_FunctionName = functionName;
            m_ReturnType = returnType;
        }

        public string GetFunctionName()
        {
            return m_FunctionName;
        }

        public string GetReturnType()
        {
            return m_ReturnType;
        }
        
        public void AddParameter(Parameter parameter)
        {
            m_Parameter.Add(parameter);
        }

        public List<Parameter> GetParameter()
        {
            return m_Parameter;
        }

        public void SetStatic(bool isStatic)
        {
            m_IsStatic = isStatic;
        }

        public bool IsStatic()
        {
            return m_IsStatic;
        }
    }
}
