namespace MPG.ReplaceConstructors.After
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

        private Loan(CapitalStrategy capitalStrategy,
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

        public static Loan CreateTermLoan(double commitment, int riskRating, DateTime? maturity)
        {
            return new Loan(new CapitalStrategyTermLoan(), commitment, 0.0, riskRating, maturity, null);
        }

        public static Loan CreateRCTL(double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(new CapitalStrategyRCTL(), commitment, outstanding, riskRating, maturity, expiry);
        }

        public static Loan CreateRevolver(double commitment, double outstanding, int riskRating, DateTime? expiry)
        {
            return CreateRevolver(new CapitalStrategyRevolver(), commitment, outstanding, riskRating, expiry);
        }

        public static Loan CreateRevolver(CapitalStrategyRevolver capitalStrategy, double commitment, double outstanding, int riskRating, DateTime? expiry)
        {
            return new Loan(capitalStrategy, commitment, outstanding, riskRating, null, expiry);
        }
    }
}