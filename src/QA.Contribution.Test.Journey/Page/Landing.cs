using TechTalk.SpecFlow;

namespace QA.Contribution.Test.Journey.Page
{
    public class Landing : PageBase
    {
        public Landing(ScenarioContext context) : base(context)
        {
        }

        public void Navigate()
        {
            Driver.Url = Configuration.Get()[ConfigurationConstants.BaseUrl];
            Driver.Navigate();
        }
    }
}
