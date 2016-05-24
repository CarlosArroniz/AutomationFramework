// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserConfig.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Config
{
    #region

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Opera;
    using OpenQA.Selenium.Safari;

    #endregion

    /// <summary>The browser config.</summary>
    public class BrowserConfig
    {
        /// <summary>The browser.</summary>
        public static BrowConfig browser = BrowConfig.ie;

        /// <summary>The environment.</summary>
        public static Environment environment = Environment.qa;

        /// <summary>The web driver.</summary>
        public static IWebDriver webDriver;

        /// <summary>The base url.</summary>
        public static string BaseUrl = string.Empty;

        /// <summary>The brow config.</summary>
        public enum BrowConfig
        {
            /// <summary>The ie.</summary>
            ie, 

            /// <summary>The chrome.</summary>
            chrome, 

            /// <summary>The firefox.</summary>
            firefox, 

            /// <summary>The edge.</summary>
            edge, 

            /// <summary>The opera.</summary>
            opera, 

            /// <summary>The safari.</summary>
            safari
        }

        /// <summary>The environment.</summary>
        public enum Environment
        {
            /// <summary>The qa.</summary>
            qa, 

            /// <summary>The po.</summary>
            po, 

            /// <summary>The dev.</summary>
            dev, 

            /// <summary>The localhost.</summary>
            localhost, 

            /// <summary>The uat.</summary>
            uat
        }

        /// <summary>The driver.</summary>
        public static ISearchContext Driver => webDriver;

        /// <summary>The title.</summary>
        public static string Title => webDriver.Title;

        /// <summary>The goto.</summary>
        /// <param name="url">The url.</param>
        public static void Goto(string url)
        {
            webDriver.Url = BaseUrl + url;
        }

        /// <summary>The init.</summary>
        public static void Init()
        {
            switch (environment)
            {
                case Environment.localhost:
                    BaseUrl = string.Empty;
                    break;
                case Environment.dev:
                    BaseUrl = string.Empty;
                    break;
                case Environment.qa:
                    BaseUrl = string.Empty;
                    break;
                case Environment.po:
                    BaseUrl = string.Empty;
                    break;
                case Environment.uat:
                    BaseUrl = string.Empty;
                    break;
            }

            switch (browser)
            {
                case BrowConfig.ie:
                    var options = new InternetExplorerOptions
                                      {
                                          EnableNativeEvents = true, 
                                          IntroduceInstabilityByIgnoringProtectedModeSettings =
                                              true, 
                                          IgnoreZoomLevel = true, 
                                          EnsureCleanSession = true, 
                                          RequireWindowFocus = false, 
                                          PageLoadStrategy =
                                              InternetExplorerPageLoadStrategy.Eager
                                      };
                    webDriver = new InternetExplorerDriver(options);
                    webDriver.Manage().Window.Maximize();
                    break;

                case BrowConfig.chrome:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case BrowConfig.firefox:
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case BrowConfig.edge:
                    var edgeoptions = new EdgeOptions { PageLoadStrategy = EdgePageLoadStrategy.Eager };
                    webDriver = new EdgeDriver(edgeoptions);
                    webDriver.Manage().Window.Maximize();
                    break;

                case BrowConfig.opera:
                    webDriver = new OperaDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case BrowConfig.safari:
                    webDriver = new SafariDriver();
                    webDriver.Manage().Window.Maximize();
                    break;
            }
        }

        /// <summary>The clean up driver.</summary>
        public static void CleanUpDriver()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Close();
            webDriver.Quit();
        }
    }
}