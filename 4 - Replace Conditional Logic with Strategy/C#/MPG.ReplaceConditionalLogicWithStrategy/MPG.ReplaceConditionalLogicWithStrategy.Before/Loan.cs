﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MPG.ReplaceConditionalLogicWithStrategy.Before
{
    public class Loan
    {
        private const int MillisPerDay = 86400000;
        private const int DaysPerYear = 365;

        private readonly double _commitment;
        private readonly int _riskRating;
        private readonly double _outstanding;
        private readonly DateTime? _maturity;
        private readonly DateTime? _expiry;
        private readonly List<Payment> _payments = new List<Payment>();
        private readonly DateTime _start;
        private readonly DateTime? _today;
        private double _unusedPercentage;

        public Loan(
            double commitment, 
            double outstanding,
            int riskRating,
            DateTime? maturity, 
            DateTime? expiry, 
            DateTime start,
            DateTime? today)
        {
            _commitment = commitment;
            _riskRating = riskRating;
            _outstanding = outstanding;
            _unusedPercentage = 1.0;
            _maturity = maturity;
            _expiry = expiry;
            _start = start;
            _today = today;
        }

        internal void SetUnusedPercentage(double unusedPercentage)
        {
            _unusedPercentage = unusedPercentage;
        }

        public double Duration()
        {
            if (!_expiry.HasValue & _maturity.HasValue)
            {
                return WeightedAverageDuration();
            }
            else if (_expiry.HasValue && !_maturity.HasValue)
            {
                return YearsTo(_expiry.Value);
            }

            return 0.0;
        }

        public double Capital()
        {
            if (!_expiry.HasValue && _maturity.HasValue)
            {
                // term loan
                return _commitment * Duration() * RiskFactor();
            }

            if (_expiry.HasValue && !_maturity.HasValue)
            {
                if(GetUnusedPercentage() != 1.0)
                {
                    // advised line
                    return _commitment * GetUnusedPercentage() * Duration() * RiskFactor();
                }
                else
                {
                    // revolver
                    return (OutstandingRiskAmount() * Duration() * RiskFactor()) 
                           + (UnusedRiskAmount() * Duration() * UnusedRiskFactor());
                }
            }

            return 0.0;
        }

        public void Payment(double amount, DateTime date)
        {
            _payments.Add(new Payment(amount, date));
        }

        private double OutstandingRiskAmount()
        {
            return _outstanding;
        }

        private double GetUnusedPercentage()
        {
            return _unusedPercentage;
            }

        private double UnusedRiskAmount()
        {
            return _commitment - _outstanding;
        }

        private double WeightedAverageDuration()
        {
            var duration = 0.0;
            var weightedAverage = _payments.Sum(payment => YearsTo(payment.Date) * payment.Amount);
            var sumOfPayments = _payments.Sum(payment => payment.Amount);

            if(_commitment != 0.0)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }

        private double YearsTo(DateTime endDate)
        {
            var beginDate = _today ?? _start;
            var beginDateMilliseconds = new DateTimeOffset(beginDate).ToUnixTimeMilliseconds();
            var endDateMilliseconds = new DateTimeOffset(endDate).ToUnixTimeMilliseconds();
            return ((endDateMilliseconds - beginDateMilliseconds) / MillisPerDay) / DaysPerYear;
        }

        private double RiskFactor()
        {
            return RiskFactors.ForRating(_riskRating);
        }

        private double UnusedRiskFactor()
        {
            return UnusedRiskFactors.ForRating(_riskRating);
        }

        public static Loan NewTermLoan(int commitment, DateTime start, DateTime maturity, int riskRating)
        {
            return new Loan(commitment, commitment, riskRating, maturity, null, start, null);
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new Loan(commitment, 0, riskRating, null, expiry, start, null);
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3) return null;
            var advisedLine = new Loan(commitment, 0, riskRating, null, expiry, start, null);
            advisedLine.SetUnusedPercentage(0.1);
            return advisedLine;
        }
    }
}
