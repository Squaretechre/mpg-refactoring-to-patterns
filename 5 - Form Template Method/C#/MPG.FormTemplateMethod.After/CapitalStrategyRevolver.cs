﻿namespace MPG.FormTemplateMethod.After
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return Outstanding(loan) + Unused(loan);
        }

        private double Outstanding(Loan loan)
        {
            return base.Capital(loan);
        }

        protected override double RiskAmountFor(Loan loan)
        {
            return loan.OutstandingRiskAmount();
        }

        private double Unused(Loan loan)
        {
            return loan.UnusedRiskAmount() * Duration(loan) * UnusedRiskFactor(loan);
        }
    }
}