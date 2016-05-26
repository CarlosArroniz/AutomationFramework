// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInPage.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Pages
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using OpenQA.Selenium.Support.PageObjects;

    using ScioAutomationFramework.Extenciones;

    using static ScioAutomationFramework.Config.BrowserConfig;

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
            var xpath = Extentions.GetElementXPath(this.username, webDriver);

            MessageBox.Show(xpath, "The XPath");
            //Extentions.sendKeys(username, "fredyarroniz@hotmail.com");

            //var attribute = this.username.GetAttribute("tagname");
            
            var asd = Extentions.getAbsoluteXPath(username);

            IList<IWebElement> allFromChild = webDriver.FindElements(By.XPath(asd + "/*"));

            var attrib =
                (string)
                ((IJavaScriptExecutor)webDriver).ExecuteScript(
                    "return arguments[0].innerHTML;",
                    allFromChild.ElementAt(0));

            var ids = allFromChild.ElementAt(0).GetAttribute("id");

            MessageBox.Show(allFromChild.Count.ToString(), "The XPath");

        }
    }
}