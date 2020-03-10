﻿namespace MPG.FormTemplateMethod.Before
{
    using System;
    using System.Linq;

    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return loan.GetCommitment() * Duration(loan) * RiskFactor(loan);
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