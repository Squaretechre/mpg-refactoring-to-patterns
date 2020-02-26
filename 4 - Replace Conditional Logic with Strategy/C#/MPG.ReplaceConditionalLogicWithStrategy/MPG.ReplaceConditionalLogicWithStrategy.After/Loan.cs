using System;
using System.Collections.Generic;

// Steps:
// 1. Create class CapitalStrategy
// 2. Declare Capital in CapitalStrategy
// 3. Copy Capital and anything easy from Loan to CapitalStrategy
// 4. Figure out what is needed from a Loan instance, decide next move use context object or data parameters?
// 5. Add getter methods for data that is needed from the context
// 6. Make Loan delegate to CapitalStrategy.Capital
// 7. Move YearsTo, WeightedAverageDuration and Duration to CapitalStrategy
// 8. Make Loan delegate to CapitalStrategy.Duration
// 9. Remove unused code from Loan 
// 10. Extract CapitalStrategy to field
// 11. Extract parameter on field initialization so that CapitalStrategy is passed in via constructor
// 12. Create CapitalStrategyTermLoan, move WeightedAverageDuration to it
// 13. Swap CapitalStrategy for CapitalStrategyTerm loan in factory method
// 14. Delete WeightedAverageDuration from CapitalStrategy as it's only needed for term loans
// 15. Create CapitalStrategyAdvisedLine, move Capital logic, replace in factory method, remove unused code
// 16. Create CapitalStrategyRevolver, move Capital logic, replace in factory method, remove unused code
// 17. Make CapitalStrategy an abstract class, make Capital abstract

namespace MPG.ReplaceConditionalLogicWithStrategy.After
{
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

        public Loan(
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

        internal void SetUnusedPercentage(double unusedPercentage)
        {
            _unusedPercentage = unusedPercentage;
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
    }
}
