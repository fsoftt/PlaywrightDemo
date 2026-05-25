using PortfolioAutomation.Core;

namespace PortfolioAutomation.Flows
{
    public class FlowBase
    {
        protected readonly Logger logger;

        public FlowBase()
        {
            logger = Logger.Get();
        }
    }
}
