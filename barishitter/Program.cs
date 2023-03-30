using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Emulation;
using OpenQA.Selenium.Support.UI;
using System.IO;
namespace barishitter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                if (!File.Exists("account.txt"))
                {
                    File.Create("account.txt"); //Enter your roblox login informations at this txt like username:password
                }

                IWebDriver driver = new ChromeDriver();
                var wait = new WebDriverWait(driver, new TimeSpan(0, 5, 0));

                    var RBXinfo = File.ReadAllText("account.txt");
                    string R1 = RBXinfo.Substring(0, RBXinfo.IndexOf(":"));
                    string R2 = RBXinfo.Substring(RBXinfo.IndexOf(":") + 1);

                driver.Navigate().GoToUrl("https://www.roblox.com/login");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-username"))).SendKeys(R1);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-password"))).SendKeys(R2);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button"))).Click();

                Console.WriteLine("Enter paypal login informations");
                var info = Console.ReadLine().ToString();
                var user = info.Substring(0, info.IndexOf(":"));
                var pass = info.Substring(info.IndexOf(":") + 1);
                Console.WriteLine("Go to paypal cashout screen then press any key");
                Console.ReadLine();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email"))).Click();
                Thread.Sleep(1500);
                for (int i = 0; i < user.Length; i++)
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email"))).SendKeys(user[i].ToString());
                    System.Threading.Thread.Sleep(120);
                }
                Thread.Sleep(1000);
                driver.FindElement(By.Id("email")).SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(6000);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password"))).Click();
                Thread.Sleep(1500);

                for (int i = 0; i < pass.Length; i++)
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password"))).SendKeys(pass[i].ToString());
                    System.Threading.Thread.Sleep(120);
                }
                Thread.Sleep(1000);
                driver.FindElement(By.Id("password")).SendKeys(OpenQA.Selenium.Keys.Enter);
                bool asd = true;
                while (asd)
                {
                    Process[] pname = Process.GetProcessesByName("chrome");
                    if (pname.Length == 0)
                    {
                        asd = false;
                        Console.Clear();
                    }
                }
            }       
        }
    }
}
