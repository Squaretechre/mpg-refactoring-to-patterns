namespace ReplaceConstructors.Before
{
    using System;

    class Loan
    {
        private readonly CapitalStrategy capitalStrategy;
        private readonly double commitment;
        private readonly double outstanding;
        private readonly int riskRating;
        private readonly DateTime? maturity;
        private readonly DateTime? expiry;

        public Loan(double commitment, int riskRating, DateTime? maturity)
            : this(commitment, 0.0, riskRating, maturity, null) {}

        public Loan(double commitment, int riskRating, DateTime? maturity, DateTime? expiry)
            : this(commitment, 0.0, riskRating, maturity, expiry) {}
        
        public Loan(double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry)
            : this(null, commitment, outstanding, riskRating, maturity, expiry) {}
        
        public Loan(CapitalStrategy capitalStrategy, double commitment, int riskRating, DateTime? maturity, DateTime? expiry)
            : this(capitalStrategy, commitment, 0.0, riskRating, maturity, expiry) {}
        
        public Loan(CapitalStrategy capitalStrategy,
            double commitment,
            double outstanding,
            int riskRating,
            DateTime? maturity,
            DateTime? expiry)
        {
            this.commitment = commitment;
            this.outstanding = outstanding;
            this.riskRating = riskRating;
            this.maturity = maturity;
            this.expiry = expiry;
            this.capitalStrategy = capitalStrategy;

            if (capitalStrategy is null)
            {
                if (expiry is null) this.capitalStrategy = new CapitalStrategyTermLoan();
                else if (maturity is null) this.capitalStrategy = new CapitalStrategyRevolver();
                else this.capitalStrategy = new CapitalStrategyRCTL();
            }
        }

        public string TypeOfLoan()
        {
            if (capitalStrategy is CapitalStrategyTermLoan) return "Term loan";
            if (capitalStrategy is CapitalStrategyRevolver) return "Revolver loan";
            if (capitalStrategy is CapitalStrategyRCTL) return "RCTL loan";
            throw new InvalidOperationException();
        }
    }
}