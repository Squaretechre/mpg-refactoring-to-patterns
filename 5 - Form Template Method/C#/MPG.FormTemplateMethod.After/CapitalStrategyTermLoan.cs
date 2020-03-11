﻿namespace MPG.FormTemplateMethod.After
{
    using System;
    using System.Linq;

    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            // TODO - riskAmountFor * duration * riskFactor is common in CapitalStrategyAdvisedLine & CapitalStrategyTermLoan
            return RiskAmountFor(loan) * Duration(loan) * RiskFactor(loan);
        }

        private double RiskAmountFor(Loan loan)
        {
            return loan.GetCommitment();
        }

        public override double Duration(Loan loan)
        {
            return WeightedAverageDuration(loan);
        }

        private double WeightedAverageDuration(Loan loan)
        {
            var duration = 0.0;
            var weightedAverage = loan.GetPayments().Sum(payment => YearsTo(payment.Date, loan) * payment.Amount);
            var sumOfPayments = loan.GetPayments().Sum(payment => payment.Amount);

            if (Math.Abs(loan.GetCommitment()) > 0.0)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }
    }
}