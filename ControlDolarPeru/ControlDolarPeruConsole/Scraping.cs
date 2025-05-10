using ControlDolarPeru;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.DTO;
using OpenQA.Selenium.Remote;

namespace ControlDolarPeru.Console
{
    public class Scraping
    {
        public static List<FinancialEntity> ScrapingWeb(List<ConfigurationLinksResponseDTO> LinksEntity)
        {
            var EntityList = new List<FinancialEntity>();
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            options.AddArgument("--hide-scrollbars");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--log-level=3");
            var gridUrl = new Uri("http://38.25.43.50:4444/wd/hub");
            var driver = new RemoteWebDriver(gridUrl, options);
            //var driver = new ChromeDriver(options);
            try
            {
                foreach (var detail in LinksEntity)
                {
                    driver.Navigate().GoToUrl(detail.Link);
                    Thread.Sleep(2000);
                    var PurchasePrice = driver.FindElement(By.XPath(detail.PurchaseValuePath)).Text;
                    var SalePrice = driver.FindElement(By.XPath(detail.SaleValuePath)).Text;
                    if (SalePrice == string.Empty)
                    {
                        if (driver.FindElements(By.XPath("//*[@id=\"numero3\"]")).Any())
                        {
                            SalePrice = driver.FindElement(By.XPath("//*[@id=\"numero3\"]"))?.GetAttribute("value");
                        }
                        else if (driver.FindElements(By.XPath("/html/body/div[2]/section[1]/div[2]/div[1]/div/section/div/div[2]/div/div[1]/div/div/section/section/div/div/div/div/div/div/div[2]/div/div[2]/div/p[1]")).Any())
                        {
                            SalePrice = driver.FindElement(By.XPath("/html/body/div[2]/section[1]/div[2]/div[1]/div/section/div/div[2]/div/div[1]/div/div/section/section/div/div/div/div/div/div/div[2]/div/div[2]/div/p[1]"))?.GetAttribute("data-price");
                        }

                    }
                    string pattern = @"[0-9]+(?:[\.,][0-9]+)?";
                    Match purchaseMatch = Regex.Match(PurchasePrice, pattern);
                    Match saleMatch = Regex.Match(SalePrice, pattern);
                    var mathPurchasePrice = decimal.Parse(purchaseMatch.Value.Replace(",", "."));
                    var mathSalePrice = decimal.Parse(saleMatch.Value.Replace(",", "."));
                    EntityList.Add(new FinancialEntity(detail.IdProvider, mathPurchasePrice, mathSalePrice));
                }

            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                driver.Quit();
                driver.Dispose();
            }
            return EntityList;
        }


    }   
}
