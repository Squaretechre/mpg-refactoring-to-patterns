﻿namespace MPG.FormTemplateMethod.After
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            // TODO - riskAmountFor * duration * riskFactor is common in CapitalStrategyAdvisedLine & CapitalStrategyTermLoan
            return RiskAmountFor(loan) * Duration(loan) * RiskFactor(loan);
        }

        protected override double RiskAmountFor(Loan loan)
        {
            return loan.GetCommitment() * loan.GetUnusedPercentage();
        }
    }
}