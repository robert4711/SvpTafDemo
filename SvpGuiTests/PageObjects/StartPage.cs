using TAF.WebSupport;

namespace SvpGuiTests.PageObjects
{
    public static class StartPage
    {
        public static DomElement SammastallningDropDown()
        {
            return new DomElement(By
                .TagName("li")
                .AndByClass("mega hiderule200"));
        }

        public static DomElement PlantbalansSelection()
        {
            return new DomElement(By
                .TagName("a")
                .AndByAttributeValue("href", "/Plantbalans.aspx")
                .AndByTextContainsString("Plantbalans"));
        }
    }
}
