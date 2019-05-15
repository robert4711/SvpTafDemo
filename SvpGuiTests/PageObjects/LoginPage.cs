using TAF.WebSupport;

namespace SvpGuiTests.PageObjects
{
    public static class LoginPage
    {
        public static DomElement UserNameTextBox()
        {
            return new DomElement(By
                .Id("tbNamn"));
        }

        public static DomElement PasswordTextBox()
        {
            return new DomElement(By
                .Id("tbPassword"));
        }

        public static DomElement LoggaInButton()
        {
            return new DomElement(By
                .Id("btnLoggaIn"));
        }
    }
}