using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Types;
using Utils;

using Utils.Logger;

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

        Types.InterfaceData IRepositoryHandler.HandleRepository(EA.Repository interfaceElement)
        {
            m_Data = new Types.InterfaceData();

            //EA.Package package = activityDiagram.GetTreeSelectedPackage();
            //m_DiagramOfInterest = activityDiagram;

            ////MessageBox.Show(package.Name);

            //foreach (EA.Element e in package.Elements)
            //{
            //    ElementType type = EnumUtil.ParseEnum<ElementType>(e.Type, ElementType.Unknown);
            //   // MessageBox.Show(e.Type.ToString());
            //    Log.Info(e.Type.ToString());
            //    HandleType(type, e);
            //}

            //m_Data.GetTransitionTable().PrintTable();

            //CleanUpTransitionTable();
            //Log.Info("cleaned");
            //m_Data.GetTransitionTable().PrintTable();

            //m_Data.GetTransitionTable().GetRows().Sort(new TableComparer());

            //Log.Info("sorted");
            //m_Data.GetTransitionTable().PrintTable();

            //Activity errorCurrentActivity = new Activity("Any", ElementType.Activity, -1);

            //string errorTransitionGuard = "";

            //Activity errorNextActivity = new Activity("ActivityFinal", ElementType.Activity, -1);

            //Row errorRow = new Row(errorCurrentActivity, "", "FsmError", errorNextActivity, errorTransitionGuard, -1);

            //m_Data.GetTransitionTable().AddRow(errorRow);

            //FillActionsAndGuards();

            //FetchEnumActivities();

            return m_Data;
        }

        private void HandleType(ElementType type, EA.Element element)
        {
            Log.Info("type=" + type.ToString());
            ////MessageBox.Show("type=" + type.ToString() + " typeOfElement=" + element.Type.ToString() + " name=" + element.Name.ToString());
            //switch (type)
            //{
            //    case ElementType.Activity:
            //    {
            //        HandleActivity(element);
            //        break;
            //    }
            //    case ElementType.StateNode:
            //    {
            //        HandleStateNode(element);
            //        break;
            //    }
            //}
        }
    }
}
