using System;
using NUnit.Framework;
using SampleSeleniumPOMFramework.PageRepository;
using SampleSeleniumPOMFramework.Common;
using OpenQA.Selenium;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;

namespace SampleSeleniumPOMFramework
{
    [TestFixture]
    public class FakeBarTest
    {
        static int weightUsageCount = 0;
        static public string testURL = ConfigurationManager.AppSettings["URL"].ToLower();

        [TestFixtureSetUp]
        //[SetUp]
        public void Setup()
        {
            DriverUtil.LaunchBrowser();
            
        }

        [TestFixtureTearDown]
        //[TearDown]
        public void TearDown()
        {
            DriverUtil.Teardown();

        }

        [Test]
        [Description("Test to find fake bar")]
        public void FindFakeBar()
        {
            
            DriverUtil.NavigateToURL(testURL);
            Thread.Sleep(1000);
            List<int> allBars = new List<int>();
            List<IWebElement> items = NavigateTo.GoldBars.GoldBarItems();
            foreach (var item in items)
                allBars.Add(Int32.Parse(item.Text));
           
            SetToUse(allBars);
        }

        public void SetToUse(List<int> barList)
        {
            int n = barList.Count();
            if (n < 1)
            {
                //If length is lower than 1, no bars are provided
                Console.WriteLine("No bars");
            }
            else if (n == 1)
            {
                //If one bar left, it is the lighter bar
                ClickBarInfo(barList[0]);
            }
            else
            {
                List<int> set1 = new List<int>();
                List<int> set2 = new List<int>();
                List<int> set3 = new List<int>();
                for (int i = 0; i < (n / 2); i++)
                {
                    set1.Add(barList[i]);
                    NavigateTo.GoldBars.LeftBox(i).SendKeys(barList[i].ToString());
                }
                for (int j = n / 2; j < 2 * (n / 2); j++)
                {
                    set2.Add(barList[j]);
                    NavigateTo.GoldBars.RightBox(j).SendKeys(barList[j].ToString());
                }
                for (int k = 2 * (n / 2); k < n; k++)
                {
                    set3.Add(barList[k]);
                }

                int difference = WeighToFindDifference(set1, set2);

                // int coin = diffScale(set1, set2);
                if (difference == 0)
                {
                    //Set 1 is lighter
                    SetToUse(set1);
                }
                else if (difference == 1)
                {
                    //Set 2 is lighter
                    SetToUse(set2);
                }
                else
                {
                    //Balanced
                    SetToUse(set3);
                }
            }
        }

        public int WeighToFindDifference(List<int> set1, List<int> set2)
        {
            weightUsageCount++;
            NavigateTo.GoldBars.Weigh().Click();
            Thread.Sleep(1000);
            string result= NavigateTo.GoldBars.Result().Text;
            Thread.Sleep(1000);
            NavigateTo.GoldBars.Reset().Click();
            if (result == "<")
                return 0;
            else if (result == ">")
                return 1;
            else
                return 2;
        }

        public void ClickBarInfo(int theBar)
        {
            NavigateTo.GoldBars.TheBar(theBar).Click();
            DriverUtilities.IsAlertPresent();
            Console.WriteLine("Defect bar Weight : " + theBar);
            Console.WriteLine("Alert message :" + DriverUtilities.CloseAlertAndGetItsText());
            Console.WriteLine("Number of weighings :" + weightUsageCount);
        }

   
    }
}
