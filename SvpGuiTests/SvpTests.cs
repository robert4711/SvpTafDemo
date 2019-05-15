using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using SvpGuiTests.PageObjects;
using TAF.Core;
using TAF.Logging;
using TAF.WebSupport;
using TAF.WebSupport.SeleniumAdapter;

namespace SvpGuiTests
{
    [TestClass]
    public class SvpTests : TestSet
    {
        private WebInteraction _web;

        [TestInitialize]
        public void Init()
        {
            _web = new WebInteraction(CurrentTestCase.TestCaseResult.LogPostList,
                new SeleniumTafDriver(CurrentTestCase.TestCaseResult.LogPostList, new ChromeDriver()));

            CurrentTestCase.AddReport(new TestCaseExecutionPlainTextReport());
            CurrentTestCase.AddReport(new TestCaseHtmlReport());

            CurrentTestCase.Log(new LogPost.LogPostInfo("Browse to Skogsvårdsportalen"));
            _web.Navigate("https://skogsvardtestintern.sveaskog.se");
        }

        [TestCleanup]
        public void TearDown()
        {
            _web.MakeSureDriverIsClosed();
        }

        [TestMethod]
        public void FirstTest()
        {
            // Logga in
            _web.Write(LoginPage.UserNameTextBox(), Definitions.User);
            _web.Write(LoginPage.PasswordTextBox(), Definitions.Password, performPostWriteCheck: false);
            _web.Click(LoginPage.LoggaInButton());

            // Gå till Sammanställning->Plantbalans
            _web.Click(StartPage.SammastallningDropDown());
            _web.Click(StartPage.PlantbalansSelection());

            // Verifiera innehåll
            _web.Verify().CurrentUrl("https://skogsvardtestintern.sveaskog.se/Plantbalans.aspx");
            _web.Verify(PlantbalansPage.PlantbalansHeader()).Exists();
        }
    }
}
