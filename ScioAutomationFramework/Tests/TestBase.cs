// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Tests
{
    #region

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ScioAutomationFramework.Config;

    #endregion

    /// <summary>The test base.</summary>
    [TestClass]
    public class TestBase
    {
        /// <summary>The clean up.</summary>
        [TestCleanup]
        public void CleanUp()
        {
            BrowserConfig.CleanUpDriver();
        }

        /// <summary>The test setup.</summary>
        [TestInitialize]
        public void TestSetup()
        {
            BrowserConfig.browser = BrowserConfig.BrowConfig.ie;
            BrowserConfig.environment = BrowserConfig.Environment.qa;
            BrowserConfig.Init();
        }
    }
}