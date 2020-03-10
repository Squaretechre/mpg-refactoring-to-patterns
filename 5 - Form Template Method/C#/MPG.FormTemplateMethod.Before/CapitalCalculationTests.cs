namespace MPG.FormTemplateMethod.Before
{
    using System;
    using Xunit;

    public class CapitalCalculationTests
    {
        private const int HighRiskRating = 1;
        private const int LoanAmount = 10000;

        [Fact]
        public void capital_term_loan()
        {
            var start = new DateTime(2003, 11, 20);
            var maturity = new DateTime(2006, 11, 20);
            var termLoan = Loan.NewTermLoan(LoanAmount, start, maturity, HighRiskRating);

            termLoan.Payment(1000.00, new DateTime(2004, 11, 20));
            termLoan.Payment(1000.00, new DateTime(2005, 11, 20));
            termLoan.Payment(1000.00, new DateTime(2006, 11, 20));
           
            Assert.Equal(2, termLoan.Duration());
            Assert.Equal(210, termLoan.Capital());
        }

        [Fact]
        public void capital_advised_line()
        {
            var start = new DateTime(2003, 11, 20);
            var expiry = new DateTime(2005, 11, 20);
            var loan = Loan.NewAdvisedLine(LoanAmount, start, expiry, HighRiskRating);

            Assert.Equal(2, loan.Duration());
            Assert.Equal(21, loan.Capital());
        }

        [Fact]
        public void capital_revolver()
        {
            var start = new DateTime(2003, 11, 20);
            var expiry = new DateTime(2006, 11, 20);
            var loan = Loan.NewRevolver(LoanAmount, start, expiry, HighRiskRating);

            Assert.Equal(3, loan.Duration());
            Assert.Equal(315, loan.Capital());
        }
    }
}
