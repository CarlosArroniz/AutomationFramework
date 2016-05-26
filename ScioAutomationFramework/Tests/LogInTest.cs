// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInTest.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Tests
{
    #region

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using ScioAutomationFramework.Config;
    using ScioAutomationFramework.Extenciones;
    using ScioAutomationFramework.Pages;

    #endregion

    /// <summary>The log in test.</summary>
    [TestClass]
    public class LogInTest : TestBase
    {
        /// <summary>The log in.</summary>
        [TestMethod]
        public void LogIn()
        {
            Pages.LogInPage.Goto();
            Extentions.WaitFor(BrowserConfig.webDriver, By.Id("login-full-wrapper"), 30);
            Pages.LogInPage.LogIn();
        }
    }
}