using System;
using Xunit;

namespace MPG.ReplaceConditionalLogicWithStrategy.Before
{
    public class CapitalCalculationTests
    {
        private const int HIGH_RISK_RATING = 1;
        private const int LOAN_AMOUNT = 10000;

        [Fact]
        public void capital_term_loan()
        {
            var start = new DateTime(2003, 11, 20);
            var maturity = new DateTime(2006, 11, 20);
            var termLoan = Loan.NewTermLoan(LOAN_AMOUNT, start, maturity, HIGH_RISK_RATING);

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
            var loan = Loan.NewAdvisedLine(LOAN_AMOUNT, start, expiry, HIGH_RISK_RATING);

            Assert.Equal(2, loan.Duration());
            Assert.Equal(21, loan.Capital());
        }

        [Fact]
        public void capital_revolver()
        {
            var start = new DateTime(2003, 11, 20);
            var expiry = new DateTime(2006, 11, 20);
            var loan = Loan.NewRevolver(LOAN_AMOUNT, start, expiry, HIGH_RISK_RATING);

            Assert.Equal(3, loan.Duration());
            Assert.Equal(315, loan.Capital());
        }
    }
}
