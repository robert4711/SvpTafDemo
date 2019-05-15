# SvpTafDemo

1) Clona ner detta projekt
2) Sätt värden på user och password i Definitions.cs
3) Bygg och kör testet


Exempel på en TestInitialize för TAF för att köra mot Browserstack:

        [TestInitialize]
        public void Init()
        {
            const string cPath = @"c:\temp";
            const string cParams = "--key BbpSXC2vy8svqwCZrzry";
            var filename = Path.Combine(cPath, "BrowserStackLocal.exe");
            Process.Start(filename, cParams);
            var capability = new DesiredCapabilities();
            capability.SetCapability("browserName", "iPhone");
            capability.SetCapability("browserstack.debug", "true");
            capability.SetCapability("device", "iPhone 7");
            capability.SetCapability("realMobile", "true");
            capability.SetCapability("os_version", "10.3");
            capability.SetCapability("browserstack.user", "DIN BROWSERSTACK-ANVÄNDARE");
            capability.SetCapability("browserstack.key", "DIN BROWSERSTACK-KEY");

            _web = new WebInteraction(CurrentTestCase.TestCaseResult.LogPostList,
                new SeleniumTafDriver(CurrentTestCase.TestCaseResult.LogPostList,
                    new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability)));

            CurrentTestCase.AddReport(new TestCaseHtmlReport());
        }
