﻿namespace MPG.FormTemplateMethod.After
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        protected override double RiskAmountFor(Loan loan)
        {
            return loan.GetCommitment() * loan.GetUnusedPercentage();
        }
    }
}