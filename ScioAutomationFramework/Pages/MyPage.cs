namespace ScioAutomationFramwork.Pages
{
#region
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using ScioAutomationFramework.Extenciones;
using static ScioAutomationFramework.Config.BrowserConfig; 
#endregion
public class MyPage
{
[FindsBy(How = How.Id, Using = "")]
private IWebElement ;
[FindsBy(How = How.Id, Using = "Email")]
private IWebElement Email;
[FindsBy(How = How.Id, Using = "Password")]
private IWebElement Password;
}
}
