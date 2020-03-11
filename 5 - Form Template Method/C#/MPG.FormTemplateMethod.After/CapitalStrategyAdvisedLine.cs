﻿namespace MPG.FormTemplateMethod.After
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            // TODO - x * duration * riskFactor is common in CapitalStrategyAdvisedLine & CapitalStrategyTermLoan
            return loan.GetCommitment() * loan.GetUnusedPercentage() * Duration(loan) * RiskFactor(loan);
        }
    }
}