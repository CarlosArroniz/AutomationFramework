// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassGenerator.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Extenciones
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using EnvDTE;

    using EnvDTE80;

    #endregion

    /// <summary>The class generator.</summary>
    public class ClassGenerator
    {
        /// <summary>The files generator.</summary>
        /// <param name="name">The name.</param>
        /// <param name="Elements">The elements.</param>
        public static void FilesGenerator(string name, string[] Elements)
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
                sw.WriteLine("{\n");
                sw.WriteLine("  #region\n");
                foreach (var u in usings)
                {
                    sw.WriteLine("      " + u + "\n");
                }

                sw.WriteLine("  #endregion\n");

                sw.WriteLine("  public class " + name);
                sw.WriteLine("  {");

                foreach (var e in Elements)
                {
                    sw.WriteLine("          [FindsBy(How = How.Id, Using = \"" + e + "\")]");
                    sw.WriteLine("          private static IWebElement " + e + ";" + "\n");
                }

                sw.WriteLine("public static void " + name + "Method()\n" + "{\n");
                sw.WriteLine(Elements[0] + ".SendKeys(\"value1\");");
                sw.WriteLine(Elements[1] + ".SendKeys(\"value2\");");
                sw.WriteLine("\n}");

                sw.WriteLine("          }"); // class ending
                sw.WriteLine("      }"); // namespace ending
            }
        }

        /// <summary>The add files.</summary>
        /// <param name="project">The project.</param>
        /// <param name="folderPath">The folder path.</param>
        public static void AddNewFiles()
        {
            IServiceProvider provider = null;
            var count = 0;

            DTE2 dte2;

            List<string> newFiles;

            dte2 = (DTE2)provider.GetService(typeof(DTE));

            foreach (Project project in dte2.Solution.Projects)
            {
                if (project.UniqueName.EndsWith(".csproj"))
                {
                    newFiles = (List<string>)GetFilesNotInProject(project);

                    foreach (var file in newFiles)
                    {
                        project.ProjectItems.AddFromFile(file);

                        count += newFiles.Count;
                    }
                }

                dte2.StatusBar.Text = string.Format(
                    "{0} new File{1} included in the project.", 
                    count, 
                    count == 1 ? string.Empty : "s");
            }
        }

        /// <summary>The get files not in project.</summary>
        /// <param name="project">The project.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        public static IList<string> GetFilesNotInProject(Project project)
        {
            var returnValue = new List<string>();

            var startPath = Path.GetDirectoryName(project.FullName);

            var projectFiles = GetAllProjectFiles(project.ProjectItems, ".cs");

            foreach (var file in Directory.GetFiles(startPath, "*.cs", SearchOption.AllDirectories)) if (!projectFiles.Contains(file)) returnValue.Add(file);

            return returnValue;
        }

        /// <summary>The get all project files.</summary>
        /// <param name="projectItems">The project items.</param>
        /// <param name="extension">The extension.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public static List<string> GetAllProjectFiles(ProjectItems projectItems, string extension)
        {
            var returnValue = new List<string>();

            foreach (ProjectItem projectItem in projectItems)
            {
                for (short i = 1; i <= projectItems.Count; i++)
                {
                    var fileName = projectItem.FileNames[i];

                    if (Path.GetExtension(fileName).ToLower() == extension) returnValue.Add(fileName);
                }

                returnValue.AddRange(GetAllProjectFiles(projectItem.ProjectItems, extension));
            }

            return returnValue;
        }
    }
}