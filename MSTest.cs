//Pedro Pascasio - Phone: 07508495970

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebDriverMS
{

	public class MSSearchTest
	{
		[TestMethod]
		public void Search_NumberOfMalbec()
		{
			IWebDriver driver = new ChromeDriver();
			
			driver.Navigate().GoToUrl("http://www.markandspencer.com");
			
            IWebElement globalSearch = driver.FindElement(By.Id("global-search"));// with "inspect element" I pick the "id" of the element
			globalSearch.SendKeys("Malbec");
			globalSearch.SendKeys(Keys.Enter);
			
			IList<IWebElement> elements = driver.FindElements(By.Xpath("//h3[@class='body2' and contains(text()='Malbec')]"));
			
			int malbecWines = elements.Count;//number of wines returned for a search on the word “malbec”
			System.out.println("number of Malbec wines: " + malbecWines);
			driver.Quit();
		}
		
		
		[TestMethod]
		public void Search_FiveStarsRating()
		{
			IWebDriver driver = new ChromeDriver();
			
			driver.Navigate().GoToUrl("http://www.markandspencer.com");
			
            IWebElement globalSearch = driver.FindElement(By.Id("global-search"));
			globalSearch.SendKeys("Malbec");
			globalSearch.SendKeys(Keys.Enter);
			
			IList<IWebElement> elements = driver.FindElements(By.Xpath("//span[@itemprop='ratingValue' and contains(@style,'width:100.0%')]"));
			
			int fiveStars = elements.Count;//number of wines with 5 star ratings
			System.out.println("number of wines with 5 star ratings: " + fiveStars);
			driver.Quit();
		}
		
		[TestMethod]
		public void Search_BestValue()
		{
			IWebDriver driver = new ChromeDriver();
			
			driver.Navigate().GoToUrl("http://www.markandspencer.com");
			
            IWebElement globalSearch = driver.FindElement(By.Id("global-search"));
			globalSearch.SendKeys("Malbec");
			globalSearch.SendKeys(Keys.Enter);
			
			IList<IWebElement> elements = driver.FindElements(By.Xpath("//dd[@class='price1']"));
			
			string price = ""; 
			double min = Double.parseDouble(elements[0].getText().replace("£","").replace(",",""));
			foreach (IWebElement child in elements)
			{
				price = child.getText().replace("£","").replace(",","");
				double childPrice = Double.parseDouble(price);
				if(childPrice < min)
				{
					min = childPrice;
				}
			}
			
			System.out.println("best value wine: " + min);
			driver.Quit();
		}
		
	}
		
}
