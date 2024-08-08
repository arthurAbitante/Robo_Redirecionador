using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Web;

namespace RoboRedirecionador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.lp.nemu.com.br/?utm_source=fb&utm_campaign=adset01%7C123&utm_medium=campanha01%7C1234&utm_content=ad%7C1234");

                string textoEsperado = "Em até 12 horas um especialista falará com você!";
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

                wait.Until(driver =>
                {
                    IWebElement element = driver.FindElement(By.ClassName("text-block-160"));
                    return element.Text.Contains(textoEsperado);
                });

                Thread.Sleep(10000);

                String url = driver.Url;
                Uri theUri = new Uri(url);
                string consulta = theUri.Query;

                Thread.Sleep(10000);

                String novoLink = "https://suasaudemental.com.br/" + consulta;
                String chromePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
                Process.Start(chromePath, novoLink);

            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

                driver.Quit();
            }

        }
    }
}