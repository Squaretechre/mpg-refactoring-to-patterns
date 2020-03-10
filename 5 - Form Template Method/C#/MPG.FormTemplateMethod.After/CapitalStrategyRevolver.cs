﻿namespace MPG.FormTemplateMethod.After
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return (loan.OutstandingRiskAmount() * Duration(loan) * RiskFactor(loan))
                   + (loan.UnusedRiskAmount() * Duration(loan) * UnusedRiskFactor(loan));
        }
    }
}