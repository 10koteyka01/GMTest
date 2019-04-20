using System;
using System.Threading;
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace GMTest
{
    class WebDriverHelper
    {
        private static IWebDriver _driver;
        
        public void StartDriverWithPage(string URL)
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(URL);
        }

        public void CloseDriver()
        {
            _driver.Quit();
        }

        public void FindAndFillFields(IDictionary<string, string> selectorValuePairs)
        {
            foreach (var item in selectorValuePairs)
            {
                FindelementByCss(item.Key).SendKeys(item.Value);
            }
        }

        public void ClickButtonBySelector(string selector)
        {
            FindelementByCss(selector).Click();
        }

        public string CheckRedirectPage()
        {
            WaitForResult(10000);
            return _driver.Title;
        }

        //Метод можно сделать умнее, чтобы ждал, пока появится IWebElement и потом возвращал этот элемент.
        public void WaitForResult(int timeout)
        {
            Thread.Sleep(timeout);
        }

        private IWebElement FindelementByCss(string selector)
        {
            return _driver.FindElement(By.CssSelector(selector));
        }

        public static void Main(string[] args) { }
    }
}
