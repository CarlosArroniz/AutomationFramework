// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extentions.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Extenciones
{
    #region

    using System;
    using System.IO;
    using System.Reflection;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Support.UI;

    using Enum = ScioAutomationFramework.Enums.Enum;

    #endregion

    /// <summary>The extentions.</summary>
    internal class Extentions
    {
        /// <summary>The clean file.</summary>
        /// <param name="fileName">The file name.</param>
        public static void CleanFile(string fileName)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = dir.Split(new[] { "bin" }, StringSplitOptions.None)[0];
            using (var sw = new StreamWriter(filePath + string.Empty + fileName))
            {
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>The element exists.</summary>
        /// <param name="driver">The driver.</param>
        /// <param name="by">The by.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool ElementExists(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        /// <summary>The read file.</summary>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="string[]"/>.</returns>
        public static string[] ReadFile(string fileName)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filepath = dir.Split(new[] { "bin" }, StringSplitOptions.None)[0];

            using (var sr = new StreamReader(filepath + "Data\\" + fileName))
            {
                string[] lineNames = { };
                var readFile = sr.ReadToEnd();
                var fileLines = readFile.Split(new[] { "\r\n" }, StringSplitOptions.None);

                for (var i = 0; i < fileLines.Length; i++)
                {
                    lineNames = fileLines[i].Split(',');
                }

                return lineNames;
            }
        }

        /// <summary>The searching combo use.</summary>
        /// <param name="element">The element.</param>
        /// <param name="txtElement">The txt element.</param>
        /// <param name="value">The value.</param>
        public static void searchingComboUse(IWebElement element, IWebElement txtElement, string value)
        {
            element.Click();

            var currentValue = txtElement.Text;

            if (!currentValue.Equals(string.Empty))
            {
                txtElement.Clear();
                txtElement.SendKeys(value);
            }
            else
            {
                txtElement.SendKeys(value);
            }
        }

        /// <summary>The send keys.</summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void sendKeys(IWebElement element, string value)
        {
            var currentValue = element.Text;

            if (!currentValue.Equals(string.Empty))
            {
                element.Clear();
                element.SendKeys(value);
            }
            else
            {
                element.SendKeys(value);
            }
        }

        /// <summary>The wait for.</summary>
        /// <param name="driver">The driver.</param>
        /// <param name="by">The by.</param>
        /// <param name="timeOut">The time out.</param>
        /// <returns>The <see cref="IWebElement"/>.</returns>
        public static IWebElement WaitFor(IWebDriver driver, By by, int timeOut)
        {
            var retriesNumber = timeOut / 10;

            for (var i = 0; i > retriesNumber;)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));

                    return wait.Until(drv => drv.FindElement(by));
                }
                catch (Exception)
                {
                    i++;
                }
            }

            return driver.FindElement(by);
        }

        /// <summary>The change visibility.</summary>
        /// <param name="stat">The stat.</param>
        /// <param name="element">The element.</param>
        public void changeVisibility(Enum.VisiblilityState stat, IWebElement element)
        {
            IJavaScriptExecutor jse = null;

            switch (stat)
            {
                case Enum.VisiblilityState.visible:
                    jse.ExecuteScript("arguments[0].style.visibilility='visible';", element);
                    break;
                case Enum.VisiblilityState.hidden:
                    jse.ExecuteScript("arguments[0].style.visibilility='hidden';", element);
                    break;
                case Enum.VisiblilityState.collapse:
                    jse.ExecuteScript("arguments[0].style.visibilility='collapse';", element);
                    break;
                case Enum.VisiblilityState.initial:
                    jse.ExecuteScript("arguments[0].style.visibilility='initial';", element);
                    break;
                case Enum.VisiblilityState.inherit:
                    jse.ExecuteScript("arguments[0].style.visibilility='inherit';", element);
                    break;
                default:
                    jse.ExecuteScript("arguments[0].style.visibilility='visible';", element);
                    break;
            }
        }

        /// <summary>The scroll page.</summary>
        /// <param name="side">The side.</param>
        /// <param name="scrollPx">The scroll px.</param>
        public void scrollPage(Enum.scroll side, int scrollPx)
        {
            IJavaScriptExecutor jse = null;

            switch (side)
            {
                case Enum.scroll.scrollDown:
                    jse.ExecuteScript("window.scrollBy(0,'" + scrollPx + "')", string.Empty);
                    break;

                case Enum.scroll.scrollUp:
                    jse.ExecuteScript("window.scrollBy(0,-'" + scrollPx + "')", string.Empty);
                    break;

                case Enum.scroll.scrollRigth:
                    jse.ExecuteScript("window.scrollBy('" + scrollPx + "',0)", string.Empty);
                    break;

                case Enum.scroll.scrollLeft:
                    jse.ExecuteScript("window.scrollBy(-'" + scrollPx + "',0)", string.Empty);
                    break;
            }
        }

        /// <summary>The set attribute.</summary>
        /// <param name="element">The element.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="value">The value.</param>
        public static void SetAttribute(IWebElement element, string attributeName, string value)
        {
            var wrappedElement = (IWrapsDriver)element;

            var driver = (IJavaScriptExecutor)wrappedElement;

            driver.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", element);

            var obj = new object();
        }

        /// <summary>The get absolute x path.</summary>
        /// <param name="element">The element.</param>
        /// <param name="driver">The driver.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetElementXPath(IWebElement element, IWebDriver driver)
        {
            return (string)((IJavaScriptExecutor)driver).ExecuteScript(
            "getXPath=function(node)" +
            "{" +
                "if (node.id !== '')" +
                "{" +
                    "return '//' + node.tagName.toLowerCase() + '[@id=\"'+node.id+'\"]'" +
                "}" +

                "if (node === document.body)" +
                "{" +
                    "return node.tagName.toLowerCase()" +
                "}" +

                "var nodeCount = 0;" +
                "var childNodes = node.parentNode.childNodes;" +

                "for (var i=0; i<childNodes.length; i++)" +
                "{" +
                    "var currentNode = childNodes[i];" +

                    "if (currentNode === node)" +
                    "{" +
                        "return getXPath(node.parentNode) + '/' + node.tagName.toLowerCase() + '[' + (nodeCount + 1) + ']'" +
        
                    "}" +

                    "if (currentNode.nodeType === 1 && " +
                        "currentNode.tagName.toLowerCase() === node.tagName.toLowerCase())" +
                    "{" +
                        "nodeCount++" +
                    "}" +
                "}" +
            "};" + "return getXPath(arguments[0]);",
                element);
        }

        /// <summary>The get elements id.</summary>
        /// <param name="driver">The driver.</param>
        /// <param name="elementParent">The element parent.</param>
        /// <param name="pageUrl">The page url.</param>
        /// <returns>The <see cref="string[]"/>.</returns>
        public string[] GetElementsId(IWebDriver driver, IWebElement elementParent, string pageUrl)
        {
            driver.Navigate().GoToUrl(pageUrl);

            var elements = driver.FindElements(By.XPath(string.Empty));

            return new[] { string.Empty };
        }
    }
}