// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInPage.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Pages
{
    #region

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    using ScioAutomationFramework.Extenciones;
    using ScioAutomationFramework.Pages;

    #endregion

    /// <summary>The log in page.</summary>
    public class LogInPage : Pages
    {
        /// <summary>The username.</summary>
        [FindsBy(How = How.Id, Using = "Username")]
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
            Extentions.sendKeys(username, "user");
            Extentions.sendKeys(password, "password123");
            btnLogIn.Click();
        }
    }
}