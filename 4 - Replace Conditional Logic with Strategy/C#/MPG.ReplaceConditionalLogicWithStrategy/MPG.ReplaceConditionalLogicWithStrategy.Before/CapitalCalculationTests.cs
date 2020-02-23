using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MPG.ReplaceConditionalLogicWithStrategy.Before
{
    public class CapitalCalculationTests
    {
        private const int HIGH_RISK_RATING = 1;
        private const int LOAN_AMOUNT = 1000;

        [Fact]
        public void lol()
        {
            Assert.True(true);
        }

        [Fact]
        public void term_loan_same_payments()
        {
            //var start = new DateTime(2003, 11, 20);
            //var maturity = new DateTime(2006, 11, 20);
            //var termLoan = Loan.NewTermLoan(LOAN_AMOUNT, start, maturity, HIGH_RISK_RATING);
            Assert.Equal(1, 1);
        }
    }

    public class Loan
    {
        private const int MILLIS_PER_DAY = 86400000;
        private const int DAYS_PER_YEAR = 365;

        private readonly double _commitment;
        private readonly int _riskRating;
        private readonly double _outstanding;
        private readonly double _unusedPercentage;
        private readonly DateTime _maturity;
        private readonly DateTime _expiry;
        private readonly List<Payment> _payments = new List<Payment>();
        private readonly DateTime _start;
        private readonly DateTime _today;

        public Loan(
            double commitment, 
            int riskRating,
            double outstanding, 
            double unusedPercentage,
            DateTime maturity, 
            DateTime expiry, 
            DateTime start,
            DateTime today)
        {
            _commitment = commitment;
            _riskRating = riskRating;
            _outstanding = outstanding;
            _unusedPercentage = unusedPercentage;
            _maturity = maturity;
            _expiry = expiry;
            _start = start;
            _today = today;
        }

        private double Duration()
        {
            if (_expiry == null & _maturity != null)
            {
                return WeightedAverageDuration();
            }
            else if (_expiry != null && _maturity == null)
            {
                return YearsTo(_expiry);
            }

            return 0.0;
        }

        public double Capital()
        {
            if (_expiry == null && _maturity != null)
            {
                return _commitment * Duration() * RiskFactor();
            }
            if (_expiry != null && _maturity == null)
            {
                if(GetUnusedPercentage() != 1.0)
                {
                    return _commitment * GetUnusedPercentage() * Duration() * RiskFactor();
                }
                else
                {
                    return (OutstandStandingRiskAmount() * Duration() * RiskFactor()) + (UnusedRiskAmount() * Duration() * UnusedRiskFactor());
                }
            }

            return 0.0;
        }

        private double OutstandStandingRiskAmount()
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
            var beginDate = _today == null ? _start : _today;
            var beginDateMilliSeconds = new DateTimeOffset(beginDate).ToUnixTimeMilliseconds();
            var endDateMilliSeconds = new DateTimeOffset(endDate).ToUnixTimeMilliseconds();
            return ((endDateMilliSeconds - beginDateMilliSeconds) / MILLIS_PER_DAY) / DAYS_PER_YEAR;
        }

        private double RiskFactor()
        {
            return RiskFactors.ForRating(_riskRating);
        }

        private double UnusedRiskFactor()
        {
            return UnusedRiskFactors.ForRating(_riskRating);
        }

        public static Loan NewTermLoan(int loanAmount, DateTime start, DateTime maturity, int riskRating)
        {
            throw new NotImplementedException();
        }
    }
}
