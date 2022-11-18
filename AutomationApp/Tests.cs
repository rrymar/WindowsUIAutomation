using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationApp
{
    [TestClass]
    public class Tests : AppSession
    {
        [TestMethod]
        public void Test1()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var elements = session.FindElementsByXPath(@"//*");

            var textBoxes = session.FindElementsByTagName("Edit");
            
            textBoxes[0].SendKeys("some text");
            textBoxes[1].SendKeys("some text 2");
            
            var checkBox1 = session.FindElementByName("checkBox1");
            checkBox1.Click();
            
            var button = session.FindElementByName("button1"); 
            button.Click();
            button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}