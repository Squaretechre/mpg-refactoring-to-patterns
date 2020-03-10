﻿namespace MPG.FormTemplateMethod.Before
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