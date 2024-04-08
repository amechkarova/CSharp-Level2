using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Interactions;

namespace AppiumAndroidWindows
{
    [TestClass]
    public class AppiumTests
    {
        private static AndroidDriver<AndroidElement> _driver;
        private static  AppiumLocalService _appiumLocalService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            //var args = new OptionCollector().AddArguments(GeneralOptionList.PreLaunch());
            OptionCollector argCollector = new OptionCollector().AddArguments(new KeyValuePair<string, string>("--base-path", "/wd/hub"));
            _appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1").UsingPort(4723).WithArguments(argCollector).Build();
            _appiumLocalService.Start();
            string testAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ApiDemos-debug.apk");
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appium:automationName", AutomationName.AndroidUIAutomator2);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.example.android.apis");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "7.1");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, ".ApiDemos");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, testAppPath);

            _driver = new AndroidDriver<AndroidElement>(_appiumLocalService, appiumOptions);
            _driver = new AndroidDriver<AndroidElement>(appiumOptions);
            //_driver.CloseApp(); //The API is not supported.
            //_driver.TerminateApp("com.example.android.apis");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            if (_driver != null)
            {
                _driver.StartActivity("com.example.android.apis", ".ApiDemos");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_driver != null)
            {
                _driver.TerminateApp("com.example.android.apis"); //does not close the app
                //_driver.CloseApp(); //The API is not supported.
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _appiumLocalService.Dispose();
        }
        [TestMethod]
        public void PerformActionsButtons()
        {
            By byScrollLocator = new ByAndroidUIAutomator("new UiSelector().text(\"Views\");");
            var viewsButton = _driver.FindElement(byScrollLocator);
            viewsButton.Click();

            var controlsViewButton = _driver.FindElementByXPath("//*[@text='Controls']");
            controlsViewButton.Click();

            var lightThemeButton = _driver.FindElementByXPath("//*[@text='1. Light Theme']");
            lightThemeButton.Click();
            var saveButton = _driver.FindElementByXPath("//*[@text='Save']");

            Assert.IsTrue(saveButton.Enabled);
        }

        [TestMethod]
        public void VerifyEnteredText_When_TextIsEnteredInTheTextField()
        {
            NavigateToLigthThemeControl();
            var textField = _driver.FindElementById("com.example.android.apis:id/edit");
            textField.Clear();
            textField.SendKeys("Some string is entered");

            Assert.AreEqual("Some string is entered", textField.Text);
        }

        [TestMethod]
        public void SetFirstCheckboxToTrue()
        {
            NavigateToLigthThemeControl();
            var checkbox1 = _driver.FindElementById("com.example.android.apis:id/check1");
            checkbox1.Click();
            string isChecked = checkbox1.GetAttribute("Checked");
            Assert.AreEqual("true", isChecked);
        }

        [TestMethod]
        public void SelectRadioButton()
        {
            NavigateToLigthThemeControl();
            _driver.HideKeyboard();
            var radioButton1 = _driver.FindElementById("com.example.android.apis:id/radio1");
            radioButton1.Click();
            string isChecked = radioButton1.GetAttribute("Checked");
            Assert.AreEqual("true", isChecked);
        }

        [TestMethod]
        public void AddInFavorites()
        {
            NavigateToLigthThemeControl();
            _driver.HideKeyboard();
            var star = _driver.FindElementById("com.example.android.apis:id/star");
            star.Click();
            string isChecked = star.GetAttribute("Checked");
            Assert.AreEqual("true", isChecked);
        }

        [TestMethod]
        public void ClickToggleButton()
        {
            NavigateToLigthThemeControl();
            _driver.HideKeyboard();
            var toggleButton1 = _driver.FindElementById("com.example.android.apis:id/toggle1");
            toggleButton1.Click();
            string isChecked = toggleButton1.GetAttribute("Checked");
            Assert.AreEqual("true", isChecked);
        }

        [TestMethod]
        public void SelectValueFromDropdown()
        {
            NavigateToLigthThemeControl();
            _driver.HideKeyboard();
            var dropodown = _driver.FindElementById("com.example.android.apis:id/spinner1");
            dropodown.Click();
            var earthOption = _driver.FindElementByXPath("//*[@text='Earth']");
            earthOption.Click();
            var dropdownValue = _driver.FindElementById("android:id/text1");
            Assert.AreEqual("Earth", dropdownValue.Text);
        }
        private void NavigateToLigthThemeControl()
        {
            By byScrollLocator = new ByAndroidUIAutomator("new UiSelector().text(\"Views\");");
            var viewsButton = _driver.FindElement(byScrollLocator);
            viewsButton.Click();

            var controlsViewButton = _driver.FindElementByXPath("//*[@text='Controls']");
            controlsViewButton.Click();

            var lightThemeButton = _driver.FindElementByXPath("//*[@text='1. Light Theme']");
            lightThemeButton.Click();
        }
    }
}