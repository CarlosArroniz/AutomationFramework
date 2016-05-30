// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInPage.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Pages
{
    #region

    using System;
    using System.Linq;
    using System.Windows.Forms;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    using ScioAutomationFramework.Config;
    using ScioAutomationFramework.Extenciones;

    #endregion

    /// <summary>The log in page.</summary>
    public class LogInPage : Pages
    {
        /// <summary>The username.</summary>
        [FindsBy(How = How.Id, Using = "login-full-wrapper")]
        private IWebElement username;

        /// <summary>The password.</summary>
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        /// <summary>The goto.</summary>
        public void Goto()
        {
            NavigationPage.LogInPage();
        }

        /// <summary>The log in.</summary>
        public void LogIn()
        {
            var xpath = Extentions.GetElementXPath(this.username, BrowserConfig.webDriver);

            // MessageBox.Show(xpath, "The XPath");

            // Extentions.sendKeys(this.username, "fredyarroniz@hotmail.com");
            var attribute = this.username.GetAttribute("tagname");

            // var asd = Extentions.getAbsoluteXPath(this.username);
            var allFromChild = BrowserConfig.webDriver.FindElements(By.TagName("input"));

            var el = new string[allFromChild.Count];

            for (var i = 0; i < allFromChild.Count; i++)
            {
                if (allFromChild.ElementAt(i).GetAttribute("id").Equals(string.Empty))
                {
                    el[i] = allFromChild.ElementAt(i).GetAttribute("name");
                }
                else
                {
                    el[i] = allFromChild.ElementAt(i).GetAttribute("id");
                }
                Console.WriteLine(el[i]);
            }

            ClassGenerator.FilesGenerator(el, "MyPage");

            var ids = allFromChild.ElementAt(0).GetAttribute("id");

            // MessageBox.Show(allFromChild.Count.ToString(), "The XPath");
        }
    }
}