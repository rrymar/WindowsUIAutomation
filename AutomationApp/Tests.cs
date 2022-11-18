using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationApp
{
    [TestClass]
    public class Tests
    {
        private static AutomatedApp app;
        
        [TestMethod]
        public void Test1()
        {
            TestScenario1(app);
        }

        public static void TestScenario1(AutomatedApp app)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var elements = app.Session.FindElementsByXPath(@"//*");

            var textBoxes = app.Session.FindElementsByTagName("Edit");

            textBoxes[0].SendKeys("some text");
            textBoxes[1].SendKeys("some text 2");

            var checkBox1 = app.Session.FindElementByName("checkBox1");
            checkBox1.Click();

            var button = app.Session.FindElementByName("button1");
            button.Click();
            button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            app = new AutomatedApp(Constants.AppId);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            app?.Dispose();
        }
    }
}