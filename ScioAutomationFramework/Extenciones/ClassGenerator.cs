// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassGenerator.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Extenciones
{
    #region

    using System;
    using System.IO;
    using System.Reflection;

    #endregion

    /// <summary>The class generator.</summary>
    public class ClassGenerator
    {
        /// <summary>The files generator.</summary>
        /// <param name="Elements">The elements.</param>
        /// <param name="name">The name.</param>
        public static void FilesGenerator(string[] Elements, string name)
        {
            string[] usings =
                {
                    "using OpenQA.Selenium;", "using OpenQA.Selenium.Support.Extensions;",
                    "using OpenQA.Selenium.Support.PageObjects;",
                    "using ScioAutomationFramework.Extenciones;",
                    "using static ScioAutomationFramework.Config.BrowserConfig; "
                };

            var fileName = name + ".cs";

            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var path = dir.Split(new[] { "bin" }, StringSplitOptions.None)[0];

            File.Create(path + "Pages\\" + fileName).Dispose();

            using (var sw = new StreamWriter(path + "Pages\\" + fileName))
            {
                sw.WriteLine("namespace ScioAutomationFramwork.Pages");
                sw.WriteLine("{");
                sw.WriteLine("#region");
                foreach (var u in usings)
                {
                    sw.WriteLine(u);
                }

                sw.WriteLine("#endregion");

                sw.WriteLine("public class " + name);
                sw.WriteLine("{");

                foreach (var e in Elements)
                {
                    sw.WriteLine("[FindsBy(How = How.Id, Using = \"" + e + "\")]");
                    sw.WriteLine("private IWebElement " + e + ";");
                }

                sw.WriteLine("}");//class ending
                sw.WriteLine("}");//namespace ending
            }
        }
    }
}