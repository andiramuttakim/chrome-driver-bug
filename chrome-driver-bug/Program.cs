namespace chrome_driver_bug
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Reflection;

    public class Program
    {
        public static void Main(string[] args)
        {
            var binaryDirPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var logPath = Path.Combine(binaryDirPath, "chromedriver.log");
            var url = "http://chromedriver.chromium.org/downloads/";
            var linkText = "Google Sites";

            var service = ChromeDriverService.CreateDefaultService(binaryDirPath);
            service.EnableVerboseLogging = true;
            service.LogPath = logPath;

            using (var chromeDriver = new ChromeDriver(service))
            {
                chromeDriver.Navigate().GoToUrl(url);

                var linkTextEl = chromeDriver.FindElementByLinkText(linkText);
                var location = (linkTextEl as ILocatable).LocationOnScreenOnceScrolledIntoView;
            }

            Console.ReadLine();
        }
    }
}