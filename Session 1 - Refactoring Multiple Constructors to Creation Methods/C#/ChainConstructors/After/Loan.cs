namespace ChainConstructors.After
{
    using System;

    class Loan
    {
        private readonly CapitalStrategy strategy;
        private readonly double notional;
        private readonly double outstanding;
        private readonly int rating;
        private readonly DateTime? maturity;
        private readonly DateTime? expiry;

        public Loan(double notional,
            double outstanding,
            int rating,
            DateTime? expiry)
        :this (new TermROC(), notional, outstanding, rating, expiry, null)
        {
        }

        public Loan(double notional,
            double outstanding,
            int rating,
            DateTime? expiry,
            DateTime? maturity)
        :this(new RevolvingTermROC(), notional, outstanding, rating, expiry, maturity)
        {
            this.strategy = new RevolvingTermROC();
            this.notional = notional;
            this.outstanding = outstanding;
            this.rating = rating;
            this.expiry = expiry;
            this.maturity = maturity;
        }
        
        public Loan(CapitalStrategy strategy,
            double notional,
            double outstanding,
            int rating,
            DateTime? expiry,
            DateTime? maturity)
        {
            this.strategy = strategy;
            this.notional = notional;
            this.outstanding = outstanding;
            this.rating = rating;
            this.expiry = expiry;
            this.maturity = maturity;
        }
        
        public string TypeOfLoan()
        {
            if (strategy is TermROC) return "Term loan";
            if (strategy is RevolvingTermROC) return "Revolving loan";
            if (strategy is RCTLTermROC) return "RCTL loan";
            throw new InvalidOperationException();
        }
    }
}