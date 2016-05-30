// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyPage.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramwork.Pages
{
    #region

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    #endregion

    /// <summary>The my page.</summary>
    public class MyPage
    {
        /// <summary>The __ request verification token.</summary>
        [FindsBy(How = How.Id, Using = "__RequestVerificationToken")]
        private static IWebElement __RequestVerificationToken;

        /// <summary>The email.</summary>
        [FindsBy(How = How.Id, Using = "Email")]
        private static IWebElement Email;

        /// <summary>The password.</summary>
        [FindsBy(How = How.Id, Using = "Password")]
        private static IWebElement Password;

        /// <summary>The my page method.</summary>
        public static void MyPageMethod()
        {
            __RequestVerificationToken.SendKeys("usuario1");
            Email.SendKeys("password");
        }
    }
}