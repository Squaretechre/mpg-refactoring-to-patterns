namespace MPG.ReplaceConditionalLogicWithStrategy.Before
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return loan.GetCommitment() * loan.GetUnusedPercentage() * loan.Duration() * RiskFactor(loan);
        }
    }
}