// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationPage.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Pages
{
    #region

    using ScioAutomationFramework.Config;

    #endregion

    /// <summary>The navigation page.</summary>
    public class NavigationPage
    {
        /// <summary>The log in page.</summary>
        public void LogInPage()
        {
            BrowserConfig.Goto("https://www.facebook.com/");
        }
    }
}