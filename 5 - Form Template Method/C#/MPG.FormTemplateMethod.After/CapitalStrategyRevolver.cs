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
            return x(loan) * Duration(loan) * RiskFactor(loan);
        }

        private double x(Loan loan)
        {
            return loan.OutstandingRiskAmount();
        }

        protected override double RiskAmountFor(Loan loan)
        {
            return x(loan);
        }

        private double Unused(Loan loan)
        {
            return loan.UnusedRiskAmount() * Duration(loan) * UnusedRiskFactor(loan);
        }
    }
}