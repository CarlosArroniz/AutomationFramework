// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptsGenerator.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Extenciones
{
    #region

    using System.Windows.Forms;
    using System.Xml.Linq;

    #endregion

    /// <summary>The scripts generator.</summary>
    public class ScriptsGenerator
    {
        /// <summary>The script gen.</summary>
        public static void ScriptGen()
        {
            var xelement =
                XElement.Load(
                    "C:\\Users\\caarroniz\\Desktop\\AutomationFramework\\ScioAutomationFramework\\Data\\Script.xml");

            var elementsActions = xelement.Elements();

            foreach (var el in elementsActions)
            {
                MessageBox.Show(el.Element("ElId").Value);
            }
        }
    }
}