using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSeleniumPOMFramework.PageRepository
{
    public class GoldBars
    {
        public IWebDriver driver;
        public GoldBars(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> GoldBarItems()
        {
            return driver.FindElements(By.XPath("//button[contains(@id, 'coin') and (@class='square')]")).ToList();
        }

        public IWebElement LeftBox(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='left_" + i + "']"));
        }
        public IWebElement RightBox(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='right_" + i + "']"));
        }
        public IWebElement Result()
        {
            return driver.FindElement(By.XPath("//*[@id='reset']"));
        }
        public IWebElement Reset()
        {
            return driver.FindElement(By.XPath("//button[contains(text(),'Reset')]"));
        }
        public IWebElement Weigh()
        {
            return driver.FindElement(By.XPath("//*[@id='weigh']"));
        }
        public IWebElement TheBar(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='coin_" + i + "']"));
        }

    }
}
