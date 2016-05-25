// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInPage.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Pages
{
    #region

    using System;
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
        [FindsBy(How = How.LinkText, Using = "Crea una página")]
        private IWebElement username;

        /// <summary>The password.</summary>
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        /// <summary>The btn log in.</summary>
        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement btnLogIn;

        /// <summary>The goto.</summary>
        public void Goto()
        {
            NavigationPage.LogInPage();
        }

        /// <summary>The log in.</summary>
        public void LogIn()
        {
            var xpath = Extentions.GetElementXPath(this.username, BrowserConfig.webDriver);

            MessageBox.Show(xpath,"The XPath");

            Extentions.sendKeys(this.username, "fredyarroniz@hotmail.com");
        }
    }
}