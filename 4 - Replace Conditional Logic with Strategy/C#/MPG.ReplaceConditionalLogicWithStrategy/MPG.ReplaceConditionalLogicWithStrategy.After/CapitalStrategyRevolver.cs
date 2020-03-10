namespace MPG.ReplaceConditionalLogicWithStrategy.After
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return (loan.OutstandingRiskAmount() * loan.Duration() * RiskFactor(loan))
                   + (loan.UnusedRiskAmount() * loan.Duration() * UnusedRiskFactor(loan));
        }
    }
}