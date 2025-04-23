using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;



namespace Appium
{
    public class Tests
    {
        private AndroidDriver driver;

        [SetUp]
        public void SetUp()
        {
            AppiumOptions options = new AppiumOptions();
            options.PlatformName = "Android";  // Reemplaza "appium:platformName" si es necesario
            options.AutomationName = "UiAutomator2";  // Usa la propiedad AutomationName directamente
            options.DeviceName = "Pixel_5_API_34";
            options.AddAdditionalAppiumOption("appPackage", "com.google.android.youtube");
            options.AddAdditionalAppiumOption("appActivity", "com.google.android.apps.youtube.app.WatchWhileActivity");

            driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/"), options);

            //driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/session"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void SearchInSettings()
        {
           
           //var searchIcon = driver.FindElement(By.Id("com.android.settings:id/search_action_bar_title"));
           // searchIcon.Click();
           // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

          // var searchField = driver.FindElement(By.Id("android:id/search_src_text"));
          // searchField.SendKeys("Google");

          // var result = driver.FindElement(By.XPath("//android.widget.TextView[contains(@text, 'Google')]"));
          // Assert.IsTrue(result.Displayed);
        }

        [Test]
        public void AbrirShorts()
        {
            // Espera un poco para que la app cargue
            Thread.Sleep(3000);

            try
            {
                // Usamos el resource-id para buscar el botón de "Shorts"
                var allownotBtn = driver.FindElement(By.Id("com.android.permissioncontroller:id/permission_allow_button"));
                allownotBtn.Click();
                var shortsBtn = driver.FindElement(By.XPath("(//android.widget.ImageView[@resource-id=\"com.google.android.youtube:id/image\"])[3]"));
                shortsBtn.Click();

                //we wait 15 seconds while we watch the short.
                Thread.Sleep(15000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Shorts button not found.");
            }
        }
        [Test]
        public void AbrirCuenta()
        {
            // Wait 3 seconds for the app to load.
            Thread.Sleep(3000);

            try
            {
                // We use the resource-id to search for the "account" button
                var allownotBtn = driver.FindElement(By.Id("com.android.permissioncontroller:id/permission_allow_button"));
                allownotBtn.Click();
                var YouBtn = driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"Account\"]"));
                YouBtn.Click();

                var SignInBtn = driver.FindElement(By.XPath("//android.widget.Button[@resource-id=\"com.google.android.youtube:id/button\"]"));
                SignInBtn.Click();


                Thread.Sleep(3000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Account button not found.");
            }
        }

        [Test]
        public void SearchSabrina()
        {
            var allownotBtn = driver.FindElement(By.Id("com.android.permissioncontroller:id/permission_allow_button"));
            allownotBtn.Click();
            var SearchBtn = driver.FindElement(By.XPath("//android.view.ViewGroup[@content-desc=\"Search YouTube\"]"));
            SearchBtn.Click();
            Thread.Sleep(1000);
            var Searchinput = driver.FindElement(By.Id("com.google.android.youtube:id/search_edit_text"));
            Searchinput.SendKeys("Sabrina Carpenter juno");
            Thread.Sleep(3000);
            driver.PressKeyCode(AndroidKeyCode.Enter);
            Thread.Sleep(4000);

            var SeeVideo = driver.FindElement(By.XPath("(//android.view.ViewGroup[@content-desc])[2]"));
            SeeVideo.Click();
            Thread.Sleep(6000);
            QuitarAnuncioSiExiste();
            Thread.Sleep(6000);
            QuitarAnuncioSiExiste();


            Thread.Sleep(20000);

            Console.WriteLine("The second video of 'Sabrina Carpenter' has started playing'.");



        }

        public void QuitarAnuncioSiExiste()
        {
            try
            {
                // Wait a few seconds in case an ad appears
                Thread.Sleep(5000);

                //We look for the "Skip ad" button
                var skipButton = driver.FindElement(By.Id("com.google.android.youtube:id/skip_ad_button"));

                if (skipButton.Displayed)
                {
                    skipButton.Click();
                    Console.WriteLine("Skip ad.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No ad to skip.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}