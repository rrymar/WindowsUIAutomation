using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;

namespace AutomationApp
{
    public class AutomatedApp : IDisposable
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        private WindowsDriver<WindowsElement> session;

        public WindowsDriver<WindowsElement> Session => session;

        public AutomatedApp(string appId)
        {
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", appId);
            session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(session);
            Assert.IsNotNull(session.SessionId);

            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
        }

        public void Dispose()
        {
            if (session == null) return;
            
            session.Close();

            session.Quit();
            session = null;
        }
    }
}