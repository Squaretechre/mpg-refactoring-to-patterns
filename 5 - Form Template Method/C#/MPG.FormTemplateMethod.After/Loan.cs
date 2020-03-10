namespace MPG.FormTemplateMethod.After
{
    using System;
    using System.Collections.Generic;

    public class Loan
    {
        private readonly double _commitment;
        private readonly int _riskRating;
        private readonly double _outstanding;
        private readonly DateTime? _maturity;
        private readonly DateTime? _expiry;
        private readonly List<Payment> _payments = new List<Payment>();
        private readonly DateTime _start;
        private readonly DateTime? _today;
        private double _unusedPercentage;
        private readonly CapitalStrategy _capitalStrategy;

        private Loan(
            double commitment,
            double outstanding,
            int riskRating,
            DateTime? maturity,
            DateTime? expiry,
            DateTime start,
            DateTime? today,
            CapitalStrategy capitalStrategy)
        {
            _commitment = commitment;
            _riskRating = riskRating;
            _outstanding = outstanding;
            _unusedPercentage = 1.0;
            _maturity = maturity;
            _expiry = expiry;
            _start = start;
            _today = today;
            _capitalStrategy = capitalStrategy;
        }

        public double GetCommitment()
        {
            return _commitment;
        }

        public DateTime? GetExpiry()
        {
            return _expiry;
        }

        public int GetRiskRating()
        {
            return _riskRating;
        }

        public List<Payment> GetPayments()
        {
            return _payments;
        }

        public DateTime? GetToday()
        {
            return _today;
        }

        public DateTime? GetStart()
        {
            return _start;
        }

        public double Duration()
        {
            return _capitalStrategy.Duration(this);
        }

        public double Capital()
        {
            return _capitalStrategy.Capital(this);
        }

        public void Payment(double amount, DateTime date)
        {
            _payments.Add(new Payment(amount, date));
        }

        public double OutstandingRiskAmount()
        {
            return _outstanding;
        }

        public double GetUnusedPercentage()
        {
            return _unusedPercentage;
        }

        public double UnusedRiskAmount()
        {
            return _commitment - _outstanding;
        }

        public static Loan NewTermLoan(int commitment, DateTime start, DateTime maturity, int riskRating)
        {
            return new Loan(commitment, commitment, riskRating, maturity, null, start, null, new CapitalStrategyTermLoan());
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new Loan(commitment, 0, riskRating, null, expiry, start, null, new CapitalStrategyRevolver());
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3) return null;
            var advisedLine = new Loan(commitment, 0, riskRating, null, expiry, start, null, new CapitalStrategyAdvisedLine());
            advisedLine.SetUnusedPercentage(0.1);
            return advisedLine;
        }

        private void SetUnusedPercentage(double unusedPercentage)
        {
            _unusedPercentage = unusedPercentage;
        }
    }
}
