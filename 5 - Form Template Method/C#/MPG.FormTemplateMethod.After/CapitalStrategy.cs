﻿namespace MPG.FormTemplateMethod.After
{
    using System;

    public abstract class CapitalStrategy
    {
        private const int MillisPerDay = 86400000;
        private const int DaysPerYear = 365;

        public abstract double Capital(Loan loan);

        public virtual double Duration(Loan loan)
        {
            return YearsTo(loan.GetExpiry().Value, loan);
        }

        protected double RiskFactor(Loan loan)
        {
            return RiskFactors.ForRating(loan.GetRiskRating());
        }

        protected double UnusedRiskFactor(Loan loan)
        {
            return UnusedRiskFactors.ForRating(loan.GetRiskRating());
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