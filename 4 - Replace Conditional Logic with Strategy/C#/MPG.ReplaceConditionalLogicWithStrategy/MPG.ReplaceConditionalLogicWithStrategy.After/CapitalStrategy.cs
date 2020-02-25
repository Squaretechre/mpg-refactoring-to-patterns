using System;
using System.Linq;

namespace MPG.ReplaceConditionalLogicWithStrategy.After
{
    public abstract class CapitalStrategy
    {
        private const int MillisPerDay = 86400000;
        private const int DaysPerYear = 365;

        public abstract double Capital(Loan loan);

        public virtual double Duration(Loan loan)
        {
            return YearsTo(loan.GetExpiry().Value, loan);
        }

        protected static double RiskFactor(Loan loan)
        {
            return RiskFactors.ForRating(loan.GetRiskRating());
        }

        protected static double UnusedRiskFactor(Loan loan)
        {
            return UnusedRiskFactors.ForRating(loan.GetRiskRating());
        }

        private double WeightedAverageDuration(Loan loan)
        {
            var duration = 0.0;
            var weightedAverage = loan.GetPayments().Sum(payment => YearsTo(payment.Date, loan) * payment.Amount);
            var sumOfPayments = loan.GetPayments().Sum(payment => payment.Amount);

            if (loan.GetCommitment() != 0.0)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }

        protected double YearsTo(DateTime endDate, Loan loan)
        {
            var beginDate = loan.GetToday().HasValue ? loan.GetToday().Value : loan.GetStart().Value;
            var beginDateMilliseconds = new DateTimeOffset(beginDate).ToUnixTimeMilliseconds();
            var endDateMilliseconds = new DateTimeOffset(endDate).ToUnixTimeMilliseconds();
            return ((endDateMilliseconds - beginDateMilliseconds) / MillisPerDay) / DaysPerYear;
        }
    }
}