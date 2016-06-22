// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptsGenerator.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Extenciones
{
    #region

    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml.Linq;

    #endregion

    /// <summary>The scripts generator.</summary>
    public class ScriptsGenerator
    {
        /// <summary>The script gen.</summary>
        public static void ScriptGen()
        {

            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var path = dir.Split(new[] { "bin" }, StringSplitOptions.None)[0];

            var xelement = XElement.Load(path + "\\Data\\Script.xml");

            var elementsActions = xelement.Elements();

            foreach (var el in elementsActions)
            {
                MessageBox.Show(el.Element("ElId").Value);

                string element, action, value;

                element = el.Element("ElId").Value;
                action = el.Element("Action").Value;
                value = el.Element("Value").Value;
                
            }
        }
    }
}