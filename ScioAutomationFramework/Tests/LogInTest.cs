// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInTest.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Tests
{
    #region

    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using ScioAutomationFramework.Config;
    using ScioAutomationFramework.Extenciones;
    using ScioAutomationFramework.Pages;

    using EnvDTE;

    using EnvDTE80;

    using Thread = System.Threading.Thread;

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
            Thread.Sleep(3000);
            Pages.LogInPage.LogIn();
        }
    }
}