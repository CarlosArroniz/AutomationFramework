// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pages.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Pages
{
    #region

    using OpenQA.Selenium.Support.PageObjects;

    using ScioAutomationFramework.Config;

    #endregion

    /// <summary>The pages.</summary>
    public class Pages
    {
        /// <summary>Gets the log in page.</summary>
        public static LogInPage LogInPage
        {
            get
            {
                return GetPage<LogInPage>();
            }
        }

        /// <summary>Gets the navigation page.</summary>
        public static NavigationPage NavigationPage
        {
            get
            {
                return GetPage<NavigationPage>();
            }
        }

        /// <summary>The get page.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="T" />.</returns>
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserConfig.Driver, page);
            return page;
        }
    }
}