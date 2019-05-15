using TAF.WebSupport;

namespace SvpGuiTests.PageObjects
{
    public static class PlantbalansPage
    {
        public static DomElement PlantbalansHeader()
        {
            return new DomElement(By
                .TagName("h2")
                .AndByExactText("Plantbalans"));
        }
    }
}
