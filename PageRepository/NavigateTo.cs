using SampleSeleniumPOMFramework.PageRepository;
using SampleSeleniumPOMFramework.Common;

namespace SampleSeleniumPOMFramework.PageRepository
{
    public static class NavigateTo
    {
      
        public static GoldBars GoldBars
        {
            get
            {
                var GoldBars = new GoldBars(DriverUtil.driver);
                return GoldBars;
            }
        }
    }

}

